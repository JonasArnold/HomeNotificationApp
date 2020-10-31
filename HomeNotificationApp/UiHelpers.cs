using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeNotificationApp
{
  public static class UiHelpers
  {
    public static void SetLabelText(Label label, string text)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (label.InvokeRequired)
      {
        label.Invoke((MethodInvoker)delegate
        {
          // Running on the UI thread
          label.Text = text;
        });
      }
      else
      {
        label.Text = text;
      }
    }

    public static void SetTextBoxText(TextBox box, string text)
    {
      // InvokeRequired required compares the thread ID of the
      // calling thread to the thread ID of the creating thread.
      // If these threads are different, it returns true.
      if (box.InvokeRequired)
      {
        box.Invoke((MethodInvoker)delegate
        {
          // Running on the UI thread
          box.Text = text;
        });
      }
      else
      {
        box.Text = text;
      }
    }
  }
}
