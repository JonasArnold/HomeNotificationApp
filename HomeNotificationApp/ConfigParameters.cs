using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeNotificationApp
{
  public class ConfigParameters
  {
    public string MqttBrokerIp { get; set; }
    public int MqttBrokerPort { get; set; }
    public string LoginUsername { get; set; }
    public string LoginPassword { get; set; }
    public string ClientName { get; set; }
  }
}
