using System;
using System.Windows.Forms;

namespace HomeNotificationApp
{
  internal partial class ConfigForm : Form
  {
    private IServiceFunctions serviceFunctions;

    internal ConfigForm(IServiceFunctions owner)
    {
      InitializeComponent();
      this.serviceFunctions = owner;
      this.UpdateConfigTextboxes();
    }


    /*
     *  UI Interface
     */
    internal void SetStatusLabel(string status)
    {
      UiHelpers.SetLabelText(labelMqttStatus, status);
    }

    internal void SetLastMessageLabel(string dateTimeString)
    {
      UiHelpers.SetLabelText(labelLastMessage, dateTimeString);
    }

    internal void UpdateConfigTextboxes()
    {
      UiHelpers.SetTextBoxText(textBoxIpBroker, Settings.Default.IpBroker);
      UiHelpers.SetTextBoxText(textBoxPortBroker, Settings.Default.PortBroker.ToString());
      UiHelpers.SetTextBoxText(textBoxLoginUsername, Settings.Default.LoginUsername);
      UiHelpers.SetTextBoxText(textBoxLoginPassword, Settings.Default.LoginPassword);
      UiHelpers.SetTextBoxText(textBoxClientName, Settings.Default.ClientName);
    }

    /* 
     *  Button clicks
     */

    private void buttonTestNotification_Click(object sender, EventArgs e)
    {
      this.serviceFunctions.DisplayTestMessage();
    }

    private void buttonSaveSettings_Click(object sender, EventArgs e)
    {
      try
      {
        Settings.Default.IpBroker = textBoxIpBroker.Text;
        Settings.Default.PortBroker = Int32.Parse(textBoxPortBroker.Text);
        Settings.Default.LoginUsername = textBoxLoginUsername.Text;
        Settings.Default.LoginPassword = textBoxLoginPassword.Text;
        Settings.Default.ClientName = textBoxClientName.Text;
        Settings.Default.Save();
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Exception: {ex.Message}", "Failed to write settings");
      }

      this.serviceFunctions.ManualReconnect();
    }

    private async void buttonReconnect_Click(object sender, EventArgs e)
    {
      buttonReconnect.Enabled = false;
      await this.serviceFunctions.ManualReconnect();
      buttonReconnect.Enabled = true;
    }
  }
}
