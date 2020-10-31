using System;
using System.Threading;
using System.Windows.Forms;

namespace HomeNotificationApp
{
  static class Program
  {
    private static string appGuid = "66d5ae44-5e4b-4294-bc7d-7f6bda8eec39";

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      // prevent multiple instances
      using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
      {
        if (!mutex.WaitOne(0, false))
        {
          MessageBox.Show("Instance already running");
          return;
        }

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new HomeNotificationContext());
      }
    }
  }
}
