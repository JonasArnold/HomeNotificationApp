using System.Threading.Tasks;

namespace HomeNotificationApp
{
  internal interface IServiceFunctions
  {
    Task ManualReconnect();

    void DisplayTestMessage();
  }
}
