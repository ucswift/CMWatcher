namespace WaveTech.CMWatcher.Client
{
	partial class ConfigureWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureWindow));
			this.btnSave = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblV6 = new System.Windows.Forms.Label();
			this.lblV5 = new System.Windows.Forms.Label();
			this.cboProfiles = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lblV3 = new System.Windows.Forms.Label();
			this.lblV2 = new System.Windows.Forms.Label();
			this.lblV1 = new System.Windows.Forms.Label();
			this.txtModemPassword = new System.Windows.Forms.TextBox();
			this.txtModemUsername = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtLogPageUrl = new System.Windows.Forms.TextBox();
			this.txtSignalPageUrl = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtModemIPAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblV4 = new System.Windows.Forms.Label();
			this.txtMonitorAddress = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(315, 307);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblV6);
			this.groupBox1.Controls.Add(this.lblV5);
			this.groupBox1.Controls.Add(this.cboProfiles);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.lblV3);
			this.groupBox1.Controls.Add(this.lblV2);
			this.groupBox1.Controls.Add(this.lblV1);
			this.groupBox1.Controls.Add(this.txtModemPassword);
			this.groupBox1.Controls.Add(this.txtModemUsername);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtLogPageUrl);
			this.groupBox1.Controls.Add(this.txtSignalPageUrl);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtModemIPAddress);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(378, 227);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cable Modem Information";
			// 
			// lblV6
			// 
			this.lblV6.AutoSize = true;
			this.lblV6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblV6.ForeColor = System.Drawing.Color.Red;
			this.lblV6.Location = new System.Drawing.Point(199, 195);
			this.lblV6.Name = "lblV6";
			this.lblV6.Size = new System.Drawing.Size(14, 17);
			this.lblV6.TabIndex = 23;
			this.lblV6.Text = "*";
			this.lblV6.Visible = false;
			// 
			// lblV5
			// 
			this.lblV5.AutoSize = true;
			this.lblV5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblV5.ForeColor = System.Drawing.Color.Red;
			this.lblV5.Location = new System.Drawing.Point(199, 164);
			this.lblV5.Name = "lblV5";
			this.lblV5.Size = new System.Drawing.Size(14, 17);
			this.lblV5.TabIndex = 22;
			this.lblV5.Text = "*";
			this.lblV5.Visible = false;
			// 
			// cboProfiles
			// 
			this.cboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboProfiles.FormattingEnabled = true;
			this.cboProfiles.Items.AddRange(new object[] {
            "Custom",
            "Motorola Surfboard"});
			this.cboProfiles.Location = new System.Drawing.Point(118, 20);
			this.cboProfiles.Name = "cboProfiles";
			this.cboProfiles.Size = new System.Drawing.Size(121, 21);
			this.cboProfiles.TabIndex = 21;
			this.cboProfiles.SelectedIndexChanged += new System.EventHandler(this.cboProfiles_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(65, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Profiles";
			// 
			// lblV3
			// 
			this.lblV3.AutoSize = true;
			this.lblV3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblV3.ForeColor = System.Drawing.Color.Red;
			this.lblV3.Location = new System.Drawing.Point(354, 126);
			this.lblV3.Name = "lblV3";
			this.lblV3.Size = new System.Drawing.Size(14, 17);
			this.lblV3.TabIndex = 19;
			this.lblV3.Text = "*";
			this.lblV3.Visible = false;
			// 
			// lblV2
			// 
			this.lblV2.AutoSize = true;
			this.lblV2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblV2.ForeColor = System.Drawing.Color.Red;
			this.lblV2.Location = new System.Drawing.Point(354, 90);
			this.lblV2.Name = "lblV2";
			this.lblV2.Size = new System.Drawing.Size(14, 17);
			this.lblV2.TabIndex = 18;
			this.lblV2.Text = "*";
			this.lblV2.Visible = false;
			// 
			// lblV1
			// 
			this.lblV1.AutoSize = true;
			this.lblV1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblV1.ForeColor = System.Drawing.Color.Red;
			this.lblV1.Location = new System.Drawing.Point(232, 55);
			this.lblV1.Name = "lblV1";
			this.lblV1.Size = new System.Drawing.Size(14, 17);
			this.lblV1.TabIndex = 17;
			this.lblV1.Text = "*";
			this.lblV1.Visible = false;
			// 
			// txtModemPassword
			// 
			this.txtModemPassword.Location = new System.Drawing.Point(117, 191);
			this.txtModemPassword.Name = "txtModemPassword";
			this.txtModemPassword.Size = new System.Drawing.Size(82, 20);
			this.txtModemPassword.TabIndex = 16;
			// 
			// txtModemUsername
			// 
			this.txtModemUsername.Location = new System.Drawing.Point(117, 160);
			this.txtModemUsername.Name = "txtModemUsername";
			this.txtModemUsername.Size = new System.Drawing.Size(82, 20);
			this.txtModemUsername.TabIndex = 15;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 194);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(94, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Modem Password:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 163);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Modem Username:";
			// 
			// txtLogPageUrl
			// 
			this.txtLogPageUrl.Location = new System.Drawing.Point(117, 123);
			this.txtLogPageUrl.Name = "txtLogPageUrl";
			this.txtLogPageUrl.Size = new System.Drawing.Size(238, 20);
			this.txtLogPageUrl.TabIndex = 12;
			// 
			// txtSignalPageUrl
			// 
			this.txtSignalPageUrl.Location = new System.Drawing.Point(117, 87);
			this.txtSignalPageUrl.Name = "txtSignalPageUrl";
			this.txtSignalPageUrl.Size = new System.Drawing.Size(238, 20);
			this.txtSignalPageUrl.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(39, 126);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Log Page Url:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Signal Page Url:";
			// 
			// txtModemIPAddress
			// 
			this.txtModemIPAddress.Location = new System.Drawing.Point(117, 52);
			this.txtModemIPAddress.Name = "txtModemIPAddress";
			this.txtModemIPAddress.Size = new System.Drawing.Size(116, 20);
			this.txtModemIPAddress.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Modem IP Address:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblV4);
			this.groupBox2.Controls.Add(this.txtMonitorAddress);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new System.Drawing.Point(13, 245);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(377, 56);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "CMWatcher Information";
			// 
			// lblV4
			// 
			this.lblV4.AutoSize = true;
			this.lblV4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblV4.ForeColor = System.Drawing.Color.Red;
			this.lblV4.Location = new System.Drawing.Point(258, 26);
			this.lblV4.Name = "lblV4";
			this.lblV4.Size = new System.Drawing.Size(14, 17);
			this.lblV4.TabIndex = 18;
			this.lblV4.Text = "*";
			this.lblV4.Visible = false;
			// 
			// txtMonitorAddress
			// 
			this.txtMonitorAddress.Location = new System.Drawing.Point(116, 23);
			this.txtMonitorAddress.Name = "txtMonitorAddress";
			this.txtMonitorAddress.Size = new System.Drawing.Size(145, 20);
			this.txtMonitorAddress.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(98, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Address to Monitor:";
			// 
			// ConfigureWindow
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 342);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConfigureWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configure CMWatcher";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ConfigureWindow_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtModemPassword;
		private System.Windows.Forms.TextBox txtModemUsername;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLogPageUrl;
		private System.Windows.Forms.TextBox txtSignalPageUrl;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtModemIPAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtMonitorAddress;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblV3;
		private System.Windows.Forms.Label lblV2;
		private System.Windows.Forms.Label lblV1;
		private System.Windows.Forms.Label lblV4;
		private System.Windows.Forms.ComboBox cboProfiles;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblV6;
		private System.Windows.Forms.Label lblV5;
	}
}