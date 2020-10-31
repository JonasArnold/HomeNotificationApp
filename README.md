# HomeNotificationApp
A simple Windows tray application, which displays received MQTT messages as a notification and plays a sound.

*This app was built to notify PCs via HomeAssistant with the Mosquitto MQTT broker installed.*

# How it works
Since Windows Services are not able to display anything for the user I have chosen to go with a WinForms Application, just for simplicity. Also it is very simple to create a Tray application with WinForms.

### HomeNotificationContext
This is the Context program. In here the MQTT connection and message transmission happens.

Also all of the logging happens in this class.

It does update the UI fields of the ConfigForm and it triggers the display of notifications.

**Display Notification**
Messages sent to the following MQTT topic get displayed as a notification:

    home/notifySys/<clientName>

**Acknowledgement**
If the Notification is clicked, an acknowledgement message is published to this MQTT topic:

    home/notifySys/<clientName>/ack
With payload: 

    received

### MessageDisplayForm
It is only possible to display a notification if the handle of a Form was already created. And for that it needs to run.

Therefore I created this hidden Form that runs all the time. It is not shown in the taskbar and has the Size of 0. 

**This Form's only job is to display the notifications.**

### ConfigForm
If you rightclick the tray icon and click on "Configuration" the ConfigForm opens up. This is where you initially setup the configuration parameters.

The arrow on the right top is to **Reconnect** to the MQTT broker.

| Parameter name | Description |
|--|--|
| MqttBrokerIp | IP of your Mosquitto broker or other MQTT brokers |
| MqttBrokerPort| Port of your Mosquitto broker or other MQTT brokers |
| LoginUsername| Username to authenticate to your MQTT broker |
| LoginPassword| Password to authenticate to your MQTT broker |
| ClientName | Unique name of this client to identify for the MQTT broker |

**You should not use the same ClientName twice in one network! Most MQTT broker will disconnect the existing client's connection if you connect with the same ClientName again.**


# Platforms / Dependencies
Framework: .NET Framework 4.7.2

UI: WinForms (for simplicity)

Libraries:
- [MQTTnet](https://github.com/chkr1011/MQTTnet)
- [NotificationWindow](https://github.com/Tulpep/Notification-Popup-Window)
- [Serilog](https://github.com/serilog)

# Logging
Logfile location: C:\log\HomeNotificationApp

Serilog is configured to create a new file every month.

# Installation
I install this app on the path: *C:\HomeNotification\V_1.0.0.1\*

Then you can easily add this to autostart. Here is the batch commands for that:

    reg add HKLM\Software\Microsoft\Windows\CurrentVersion\Run /v HomeNotificationApp /d C:\HomeNotification\V_1.0.0.1\HomeNotificationApp.exe
**RUN BATCH FILE AS ADMIN!**
