using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using Serilog;
using Serilog.Core;
using System;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using Windows.UI.Xaml.Documents;

namespace HomeNotificationApp
{
  public class HomeNotificationContext : ApplicationContext, IServiceFunctions, IMessageFeedback
  {
    ConfigForm configWindow;
    MessageDisplayForm messageWindow;
    NotifyIcon notifyIcon;
    Logger logger;

    // config settings
    IPAddress brokerIp;
    int brokerPort;
    string loginUsername, loginPassword;
    string clientName;

    // mqtt
    IMqttClient client;         // https://github.com/chkr1011/MQTTnet/wiki/Client
    IMqttClientOptions options;
    int reconnectTimeoutS = 60;
    bool reconnectFlag = false;

    public HomeNotificationContext()
    {
      // setup config window
      this.configWindow = new ConfigForm(this);
      this.messageWindow = new MessageDisplayForm(this);
      this.messageWindow.Show();

      // setup tray icon
      MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
      MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

      notifyIcon = new NotifyIcon();
      notifyIcon.Icon = Properties.Resources.AppIcon;
      notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
      {
        configMenuItem,
        exitMenuItem
      });
      notifyIcon.Visible = true;

      // setup logging
      logger = new LoggerConfiguration()
         .MinimumLevel.Debug()
         .WriteTo.File(@"C:\log\HomeNotificationApp\log.txt", rollingInterval: RollingInterval.Month)
         .CreateLogger();

      // get configuration and check if it is valid
      try
      {
        this.GetSettings();
        if (configWindow.Visible) configWindow.UpdateConfigTextboxes();
      }
      catch (Exception)
      {
        logger.Error("Failed to read configuration. Check App.config");
        this.Exit(this, null);
      }
      logger.Information("Successfully parsed configuration.");

      // connect
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
      StartMqttConnection();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private void GetSettings()
    {
      brokerIp = IPAddress.Parse(Settings.Default.IpBroker);
      brokerPort = Settings.Default.PortBroker;
      loginUsername = Settings.Default.LoginUsername;
      loginPassword = Settings.Default.LoginPassword;
      clientName = Settings.Default.ClientName;
    }

    private async Task StartMqttConnection()
    {
      configWindow.SetStatusLabel("Connecting...");   // update UI

      // get settings from file
      this.GetSettings();

      // create client
      var factory = new MqttFactory();
      client = factory.CreateMqttClient();
      options = new MqttClientOptionsBuilder()
        .WithClientId($"HomeNotification_{clientName}")
        .WithTcpServer(brokerIp.ToString(), brokerPort)
        .WithCredentials(loginUsername, loginPassword)
        .WithCleanSession()
        .Build();
      logger.Information($"Created client. Name: HomeNotification_{ clientName}");

      client.UseDisconnectedHandler(this.OnDisconnected);
      client.UseConnectedHandler(this.OnConnected);
      client.UseApplicationMessageReceivedHandler(this.OnMessageReceived);

      try
      {
        await client.ConnectAsync(options, CancellationToken.None);  // try to connect
      }
      catch
      {
        logger.Warning($"Start Connection to broker {brokerIp}:{brokerPort} failed. Retrying in {reconnectTimeoutS}s.");
        await Task.Delay(TimeSpan.FromSeconds(reconnectTimeoutS));
        await this.StartMqttConnection();
      }
    }

    private async Task OnConnected(MqttClientConnectedEventArgs arg)
    {
      logger.Information($"Successfully connected to broker on {brokerIp}:{brokerPort}");
      configWindow.SetStatusLabel("Connected");  // update UI

      await client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic($"home/notifySys/{clientName}").Build());
      logger.Information($"Subscribed to topic 'home/notifySys/{clientName}'");
    }

    private async Task OnDisconnected(MqttClientDisconnectedEventArgs arg)
    {
      logger.Warning($"Connection to broker failed or disconnected! Client was connected: {arg.ClientWasConnected} Retrying in {reconnectTimeoutS}s.");
      logger.Information($"Disconnect Reason: {arg.ReasonCode}");
      configWindow.SetStatusLabel("Disconnected");  // update UI

      if (reconnectFlag)  // if manual reconnect was called
      {
        logger.Information("Not trying to auto reconnect since manual reconnect was called.");
        reconnectFlag = false;  // reset
        return;  // do not try to reconnect automatically
      }

      if (arg.ReasonCode != MqttClientDisconnectReason.NormalDisconnection) // normal disconnection => directly reconnect
      {
        await Task.Delay(TimeSpan.FromSeconds(reconnectTimeoutS));
      }

      try
      {
        await client.ConnectAsync(options, CancellationToken.None); // Since 3.0.5 with CancellationToken
      }
      catch
      {
        logger.Warning($"Reconnecting failed.");
      }
    }

    private async Task Reconnect()
    {
      reconnectFlag = true; // prevent auto reconnect
      await client?.DisconnectAsync();
      await this.StartMqttConnection();
    }

    private void OnMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
    {
      configWindow.SetLastMessageLabel(DateTime.Now.ToString());  // update UI
      string message = Encoding.UTF8.GetString(arg.ApplicationMessage.Payload);
      logger.Information($"Received message. QoS: {arg.ApplicationMessage.QualityOfServiceLevel} Message: {message}");
      messageWindow.DisplayMessage("Benachrichtigung", message);
    }

    /*
     * Service Functions
     */
    public async Task ManualReconnect()
    {
      logger.Information("Manual reconnect");
      await this.Reconnect();
    }

    public void DisplayTestMessage()
    {
      logger.Information($"Displaying test notification.");
      messageWindow.DisplayMessage("Test Benachrichtigung", "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, " +
        "sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. " +
        "At vero eos et accusam et justo duo dolores et ea rebum.");
    }

    public async void SendAcknowledgeMessage()
    {
      this.logger.Information($"Sending acknowledge to topic 'home/notifySys/{clientName}/ack'");
      var message = new MqttApplicationMessageBuilder()
      .WithTopic($"home/notifySys/{clientName}/ack")
      .WithPayload("received")
      .WithExactlyOnceQoS()
      .WithRetainFlag()
      .Build();

      await client.PublishAsync(message, CancellationToken.None); // Since 3.0.5 with CancellationToken
    }


    /* 
     * CONFIGURATION WINDOW
     */

    void ShowConfig(object sender, EventArgs e)
    {
      // If we are already showing the window, merely focus it.
      if (configWindow.Visible)
      {
        configWindow.Activate();
      }
      else
      {
        configWindow.ShowDialog();
      }
    }

    async void Exit(object sender, EventArgs e)
    {
      await client.DisconnectAsync();
      this.messageWindow.Close();

      // We must manually tidy up and remove the icon before we exit.
      // Otherwise it will be left behind until the user mouses over.
      if (notifyIcon != null)
      {
        notifyIcon.Visible = false;
      }
      Application.Exit();
    }
  }
}
