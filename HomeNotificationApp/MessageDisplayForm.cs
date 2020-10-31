using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace HomeNotificationApp
{
  public partial class MessageDisplayForm : Form
  {
    private IMessageFeedback messageFeedback;

    internal MessageDisplayForm(IMessageFeedback messageFeedback)
    {
      InitializeComponent();
      this.messageFeedback = messageFeedback;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.ShowInTaskbar = false;
      this.Load += new EventHandler(MessageDisplayForm_Load);
    }

    void MessageDisplayForm_Load(object sender, EventArgs e)
    {
      this.Size = new Size(0, 0);
    }

    /* 
     *  Message display
     */
    internal void DisplayMessage(string title, string message)
    {
      PopupNotifier popup = new PopupNotifier();  // https://github.com/Tulpep/Notification-Popup-Window/blob/master/DemoApp/Form1.cs
      popup.Image = Properties.Resources.info_icon;
      popup.ShowGrip = false;
      popup.ImageSize = new System.Drawing.Size(70, 70);
      popup.ImagePadding = new Padding(10);
      popup.TitleText = title;
      popup.ContentText = message;
      popup.Delay = 10000;

      popup.Click += Popup_Click;

      this.Invoke((MethodInvoker)delegate
      {
        // Running on the UI thread
        popup.Popup();
        SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\Windows Unlock.wav");
        simpleSound.Play();
      });
    }

    private void Popup_Click(object sender, EventArgs e)
    {
      this.messageFeedback.SendAcknowledgeMessage();
    }
  }
}
