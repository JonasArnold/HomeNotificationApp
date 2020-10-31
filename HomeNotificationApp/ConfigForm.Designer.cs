namespace HomeNotificationApp
{
  partial class ConfigForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.textBoxIpBroker = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.labelMqttStatus = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.textBoxPortBroker = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.textBoxLoginUsername = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.textBoxLoginPassword = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.textBoxClientName = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.labelLastMessage = new System.Windows.Forms.Label();
      this.buttonSaveSettings = new System.Windows.Forms.Button();
      this.buttonTestNotification = new System.Windows.Forms.Button();
      this.buttonReconnect = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // textBoxIpBroker
      // 
      this.textBoxIpBroker.Location = new System.Drawing.Point(116, 61);
      this.textBoxIpBroker.Name = "textBoxIpBroker";
      this.textBoxIpBroker.Size = new System.Drawing.Size(233, 20);
      this.textBoxIpBroker.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 64);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(88, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "IP MQTT Broker:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(74, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "MQTT Status:";
      // 
      // labelMqttStatus
      // 
      this.labelMqttStatus.AutoSize = true;
      this.labelMqttStatus.Location = new System.Drawing.Point(113, 9);
      this.labelMqttStatus.Name = "labelMqttStatus";
      this.labelMqttStatus.Size = new System.Drawing.Size(50, 13);
      this.labelMqttStatus.TabIndex = 3;
      this.labelMqttStatus.Text = "STATUS";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 90);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(97, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Port MQTT Broker:";
      // 
      // textBoxPortBroker
      // 
      this.textBoxPortBroker.Location = new System.Drawing.Point(116, 87);
      this.textBoxPortBroker.Name = "textBoxPortBroker";
      this.textBoxPortBroker.Size = new System.Drawing.Size(233, 20);
      this.textBoxPortBroker.TabIndex = 4;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 128);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(87, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Login Username:";
      // 
      // textBoxLoginUsername
      // 
      this.textBoxLoginUsername.Location = new System.Drawing.Point(116, 125);
      this.textBoxLoginUsername.Name = "textBoxLoginUsername";
      this.textBoxLoginUsername.Size = new System.Drawing.Size(233, 20);
      this.textBoxLoginUsername.TabIndex = 6;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 154);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(85, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Login Password:";
      // 
      // textBoxLoginPassword
      // 
      this.textBoxLoginPassword.Location = new System.Drawing.Point(116, 151);
      this.textBoxLoginPassword.Name = "textBoxLoginPassword";
      this.textBoxLoginPassword.Size = new System.Drawing.Size(233, 20);
      this.textBoxLoginPassword.TabIndex = 8;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 195);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(65, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "Client name:";
      // 
      // textBoxClientName
      // 
      this.textBoxClientName.Location = new System.Drawing.Point(116, 192);
      this.textBoxClientName.Name = "textBoxClientName";
      this.textBoxClientName.Size = new System.Drawing.Size(233, 20);
      this.textBoxClientName.TabIndex = 10;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(12, 29);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(75, 13);
      this.label7.TabIndex = 12;
      this.label7.Text = "Last message:";
      // 
      // labelLastMessage
      // 
      this.labelLastMessage.AutoSize = true;
      this.labelLastMessage.Location = new System.Drawing.Point(113, 29);
      this.labelLastMessage.Name = "labelLastMessage";
      this.labelLastMessage.Size = new System.Drawing.Size(137, 13);
      this.labelLastMessage.TabIndex = 13;
      this.labelLastMessage.Text = "not yet received a message";
      // 
      // buttonSaveSettings
      // 
      this.buttonSaveSettings.Location = new System.Drawing.Point(15, 234);
      this.buttonSaveSettings.Name = "buttonSaveSettings";
      this.buttonSaveSettings.Size = new System.Drawing.Size(163, 23);
      this.buttonSaveSettings.TabIndex = 14;
      this.buttonSaveSettings.Text = "Save Settings";
      this.buttonSaveSettings.UseVisualStyleBackColor = true;
      this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
      // 
      // buttonTestNotification
      // 
      this.buttonTestNotification.Location = new System.Drawing.Point(186, 234);
      this.buttonTestNotification.Name = "buttonTestNotification";
      this.buttonTestNotification.Size = new System.Drawing.Size(163, 23);
      this.buttonTestNotification.TabIndex = 15;
      this.buttonTestNotification.Text = "Test Notification";
      this.buttonTestNotification.UseVisualStyleBackColor = true;
      this.buttonTestNotification.Click += new System.EventHandler(this.buttonTestNotification_Click);
      // 
      // buttonReconnect
      // 
      this.buttonReconnect.BackgroundImage = global::HomeNotificationApp.Properties.Resources.reconnect;
      this.buttonReconnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonReconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonReconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.buttonReconnect.Location = new System.Drawing.Point(315, 12);
      this.buttonReconnect.Name = "buttonReconnect";
      this.buttonReconnect.Size = new System.Drawing.Size(34, 33);
      this.buttonReconnect.TabIndex = 16;
      this.buttonReconnect.UseVisualStyleBackColor = true;
      this.buttonReconnect.Click += new System.EventHandler(this.buttonReconnect_Click);
      // 
      // ConfigForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(373, 269);
      this.Controls.Add(this.buttonReconnect);
      this.Controls.Add(this.buttonTestNotification);
      this.Controls.Add(this.buttonSaveSettings);
      this.Controls.Add(this.labelLastMessage);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.textBoxClientName);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.textBoxLoginPassword);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.textBoxLoginUsername);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textBoxPortBroker);
      this.Controls.Add(this.labelMqttStatus);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBoxIpBroker);
      this.Name = "ConfigForm";
      this.Text = "Home Notifications";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBoxIpBroker;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label labelMqttStatus;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBoxPortBroker;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBoxLoginUsername;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBoxLoginPassword;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox textBoxClientName;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label labelLastMessage;
    private System.Windows.Forms.Button buttonSaveSettings;
    private System.Windows.Forms.Button buttonTestNotification;
    private System.Windows.Forms.Button buttonReconnect;
  }
}

