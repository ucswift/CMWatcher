namespace WaveTech.CMWatcher.Client
{
	partial class SysTrayWindow
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
				trayIcon.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysTrayWindow));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblModemState = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblConnectionState = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblMonitorStatus = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblTotalDowntime = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblLastFailure = new System.Windows.Forms.Label();
			this.lblTotalConnectionFailures = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnOpenScreenshotsDir = new System.Windows.Forms.Button();
			this.btnConfigure = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblModemState);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.lblConnectionState);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.lblMonitorStatus);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 65);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(236, 72);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Status";
			// 
			// lblModemState
			// 
			this.lblModemState.AutoSize = true;
			this.lblModemState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblModemState.Location = new System.Drawing.Point(128, 53);
			this.lblModemState.Name = "lblModemState";
			this.lblModemState.Size = new System.Drawing.Size(30, 13);
			this.lblModemState.TabIndex = 7;
			this.lblModemState.Text = "N/A";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(50, 53);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(73, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Modem State:";
			// 
			// lblConnectionState
			// 
			this.lblConnectionState.AutoSize = true;
			this.lblConnectionState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblConnectionState.Location = new System.Drawing.Point(129, 33);
			this.lblConnectionState.Name = "lblConnectionState";
			this.lblConnectionState.Size = new System.Drawing.Size(30, 13);
			this.lblConnectionState.TabIndex = 5;
			this.lblConnectionState.Text = "N/A";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(27, 33);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(97, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Connection Status:";
			// 
			// lblMonitorStatus
			// 
			this.lblMonitorStatus.AutoSize = true;
			this.lblMonitorStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMonitorStatus.Location = new System.Drawing.Point(129, 14);
			this.lblMonitorStatus.Name = "lblMonitorStatus";
			this.lblMonitorStatus.Size = new System.Drawing.Size(48, 13);
			this.lblMonitorStatus.TabIndex = 1;
			this.lblMonitorStatus.Text = "Started";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Monitor Status:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblTotalDowntime);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.lblLastFailure);
			this.groupBox2.Controls.Add(this.lblTotalConnectionFailures);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(12, 143);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(236, 103);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Report (since last event)";
			// 
			// lblTotalDowntime
			// 
			this.lblTotalDowntime.AutoSize = true;
			this.lblTotalDowntime.Location = new System.Drawing.Point(108, 52);
			this.lblTotalDowntime.Name = "lblTotalDowntime";
			this.lblTotalDowntime.Size = new System.Drawing.Size(53, 13);
			this.lblTotalDowntime.TabIndex = 8;
			this.lblTotalDowntime.Text = "5 Minutes";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Total Downtime:";
			// 
			// lblLastFailure
			// 
			this.lblLastFailure.AutoSize = true;
			this.lblLastFailure.Location = new System.Drawing.Point(88, 77);
			this.lblLastFailure.Name = "lblLastFailure";
			this.lblLastFailure.Size = new System.Drawing.Size(129, 13);
			this.lblLastFailure.TabIndex = 6;
			this.lblLastFailure.Text = "10/15/2009 11:15:35 PM";
			// 
			// lblTotalConnectionFailures
			// 
			this.lblTotalConnectionFailures.AutoSize = true;
			this.lblTotalConnectionFailures.Location = new System.Drawing.Point(154, 28);
			this.lblTotalConnectionFailures.Name = "lblTotalConnectionFailures";
			this.lblTotalConnectionFailures.Size = new System.Drawing.Size(19, 13);
			this.lblTotalConnectionFailures.TabIndex = 5;
			this.lblTotalConnectionFailures.Text = "10";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 77);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Last Failure:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(0, 13);
			this.label4.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Total Connection Failures:";
			// 
			// btnOpenScreenshotsDir
			// 
			this.btnOpenScreenshotsDir.Location = new System.Drawing.Point(12, 252);
			this.btnOpenScreenshotsDir.Name = "btnOpenScreenshotsDir";
			this.btnOpenScreenshotsDir.Size = new System.Drawing.Size(128, 23);
			this.btnOpenScreenshotsDir.TabIndex = 3;
			this.btnOpenScreenshotsDir.Text = "Open Images Directory";
			this.btnOpenScreenshotsDir.UseVisualStyleBackColor = true;
			this.btnOpenScreenshotsDir.Click += new System.EventHandler(this.btnOpenScreenshotsDir_Click);
			// 
			// btnConfigure
			// 
			this.btnConfigure.Location = new System.Drawing.Point(173, 252);
			this.btnConfigure.Name = "btnConfigure";
			this.btnConfigure.Size = new System.Drawing.Size(75, 23);
			this.btnConfigure.TabIndex = 4;
			this.btnConfigure.Text = "Configure";
			this.btnConfigure.UseVisualStyleBackColor = true;
			this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnStart);
			this.groupBox3.Controls.Add(this.btnStop);
			this.groupBox3.Location = new System.Drawing.Point(12, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(236, 51);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Monitor Control";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(121, 19);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 5;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(30, 19);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 4;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// SysTrayWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(257, 282);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btnConfigure);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnOpenScreenshotsDir);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "SysTrayWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CMWatcher";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.SysTrayWindow_Load);
			this.VisibleChanged += new System.EventHandler(this.SysTrayWindow_VisibleChanged);
			this.Resize += new System.EventHandler(this.SysTrayWindow_Resize);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblMonitorStatus;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnOpenScreenshotsDir;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblTotalConnectionFailures;
		private System.Windows.Forms.Label lblTotalDowntime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblLastFailure;
		private System.Windows.Forms.Button btnConfigure;
		private System.Windows.Forms.Label lblConnectionState;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblModemState;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
	}
}