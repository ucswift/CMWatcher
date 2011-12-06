using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WaveTech.CMWatcher.Client.Properties;
using WaveTech.CMWatcher.Common;
using WaveTech.CMWatcher.Model;
using WaveTech.CMWatcher.Model.Events;
using WaveTech.CMWatcher.Model.Interfaces.Services;

namespace WaveTech.CMWatcher.Client
{
	public partial class SysTrayWindow : Form
	{
		#region Private Memebers
		private NotifyIcon trayIcon;
		private ContextMenu trayMenu;
		private IMonitorService monitorService;
		private bool running;
		private IEventAggregator _eventAggregator;
		private static TimeSpan _total;
		#endregion Private Members

		#region Public Events
		public event EventHandler Minimize;
		#endregion Public Events

		#region Constructor
		public SysTrayWindow()
		{
			InitializeComponent();

			running = false;

			trayMenu = new ContextMenu();
			trayMenu.MenuItems.Add("Start", OnStart);
			trayMenu.MenuItems.Add("Stop", OnStop);
			trayMenu.MenuItems.Add("-");
			trayMenu.MenuItems.Add("Configure", OnConfigure);
			trayMenu.MenuItems.Add("Reset Data", OnReset);
			trayMenu.MenuItems.Add("-");
			trayMenu.MenuItems.Add("About", OnAbout);
			trayMenu.MenuItems.Add("-");
			trayMenu.MenuItems.Add("Exit", OnExit);

			trayIcon = new NotifyIcon();
			trayIcon.Text = "CMWatcher (Stopped)";
			trayIcon.Icon = Resources.CMWatcher;

			// Add menu to tray icon and show it.
			trayIcon.ContextMenu = trayMenu;
			trayIcon.Visible = true;
			trayIcon.DoubleClick += trayIcon_Click;

			_eventAggregator = ServiceLocator.GetInstance<IEventAggregator>();
			_eventAggregator.AddListener<StatusUpdateEvent>(e => UpdateStats());
			_eventAggregator.AddListener<ConnectionUpEvent>(e => SetConnectionUp());
			_eventAggregator.AddListener<ConnectionDownEvent>(e => SetConnectionDown());
			_eventAggregator.AddListener<ModemUpEvent>(e => SetModemUp());
			_eventAggregator.AddListener<ModemDownEvent>(e => SetModemDown());

			monitorService = ServiceLocator.GetInstance<IMonitorService>();
		}
		#endregion Constructor

		#region Protected Event Handlers
		protected void SysTrayWindow_Minimize(object sender, EventArgs e)
		{
			Visible = false;
		}

		protected void trayIcon_Click(object sender, EventArgs e)
		{
			UpdateStats();

			Show();
			WindowState = FormWindowState.Normal;
			//Width = 267;
			//Height = 264;
			//Visible = Visible != true;
		}

		protected override void OnLoad(EventArgs e)
		{
			Visible = false;
			ShowInTaskbar = false;

			base.OnLoad(e);
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			monitorService.OnStop();
			SetStopped();
			running = false;

			base.OnClosing(e);
		}

		protected void OnExit(object sender, EventArgs e)
		{
			try
			{
				trayIcon.Dispose();
			}
			catch { }

			Application.Exit();
		}

		protected void OnStart(object sender, EventArgs e)
		{
			IConfigurationOptionsService cos = ServiceLocator.GetInstance<IConfigurationOptionsService>();

			if (cos.GetConfiguration() != null)
			{
				monitorService.MonitorInit(cos.GetConfiguration());
				monitorService.OnStart();

				SetStarted();
				running = true;
			}
			else
			{
				MessageBox.Show("You need to configure CMWatcher before it can monitor your connection.", "CMWatcher Error",
												MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		protected void OnStop(object sender, EventArgs e)
		{
			monitorService.OnStop();
			SetStopped();
			running = false;
		}

		protected void OnConfigure(object sender, EventArgs e)
		{
			ConfigureWindow cw = new ConfigureWindow();
			cw.Show();
		}

		protected void OnReset(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will reset all the connection history data, continue?",
				"Data Reset", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				try
				{
					IConnectionFailureService connectionFailureService = ServiceLocator.GetInstance<IConnectionFailureService>();
					connectionFailureService.DeleteAllConnectionFailures();

					MessageBox.Show("Data reset.");
				}
				catch
				{ }
			}
		}

		protected void OnAbout(object sender, EventArgs e)
		{
			CMAboutBox about = new CMAboutBox();
			about.Show();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			OnStart(this, null);
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			OnStop(this, null);
		}

		private void btnOpenScreenshotsDir_Click(object sender, EventArgs e)
		{
			string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
			path = path + "\\images\\";

			Process.Start(path);
		}

		private void btnConfigure_Click(object sender, EventArgs e)
		{
			OnConfigure(this, null);
		}

		private void SysTrayWindow_VisibleChanged(object sender, EventArgs e)
		{
			if (running)
				SetStarted();
			else
				SetStopped();
		}

		private void SysTrayWindow_Load(object sender, EventArgs e)
		{
			lblLastFailure.Text = "";
			lblTotalConnectionFailures.Text = "";
			lblTotalDowntime.Text = "";

			UpdateStats();
		}

		private void SysTrayWindow_Resize(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == WindowState)
			{
				Hide();
			}
		}
		#endregion Protected Event Handlers

		#region Private Methods
		private void SetStarted()
		{
			trayIcon.Text = "CMWatcher (Started)";

			if (Visible)
			{
				lblMonitorStatus.Text = "Started";
				lblMonitorStatus.ForeColor = Color.Green;

				btnStart.Enabled = false;
				btnStop.Enabled = true;
			}
		}

		private void SetStopped()
		{
			trayIcon.Text = "CMWatcher (Stopped)";

			if (Visible)
			{
				lblMonitorStatus.Text = "Stopped";
				lblMonitorStatus.ForeColor = Color.Red;

				btnStart.Enabled = true;
				btnStop.Enabled = false;
			}
		}

		private void UpdateStats()
		{
			List<ConnectionFailure> failures = ServiceLocator.GetInstance<IConnectionFailureService>().GetAllConnectionFailures();

			// Order the failures
			var allFailures = from f in failures
												orderby f.EndTimestamp ascending
												select f;

			// Set the last failure
			if (allFailures.Count() <= 0)
			{
				if (lblLastFailure.InvokeRequired)
					lblLastFailure.Invoke(new MethodInvoker(delegate { lblLastFailure.Text = "Never"; }));
				else
					lblLastFailure.Text = "Never";
			}
			else
			{
				if (lblLastFailure.InvokeRequired)
					lblLastFailure.Invoke(new MethodInvoker(delegate { lblLastFailure.Text = allFailures.First().EndTimestamp.ToString(); }));
				else
					lblLastFailure.Text = allFailures.First().EndTimestamp.ToString();
			}

			// Set the failure count
			if (lblTotalConnectionFailures.InvokeRequired)
				lblTotalConnectionFailures.Invoke(new MethodInvoker(delegate { lblTotalConnectionFailures.Text = failures.Count().ToString(); }));
			else
				lblTotalConnectionFailures.Text = failures.Count().ToString();

			_total = new TimeSpan();
			foreach (var f in allFailures)
			{
				_total = _total.Add(f.EndTimestamp.Subtract(f.StartTimestamp));
			}

			if (lblTotalDowntime.InvokeRequired)
				lblTotalDowntime.Invoke(new MethodInvoker(delegate { lblTotalDowntime.Text = _total.ToString(); }));
			else
				lblTotalDowntime.Text = _total.ToString();
		}

		private void SetConnectionUp()
		{
			if (lblConnectionState.InvokeRequired)
			{
				lblConnectionState.Invoke(new MethodInvoker(delegate { lblConnectionState.Text = "Online"; }));
				lblConnectionState.Invoke(new MethodInvoker(delegate { lblConnectionState.ForeColor = Color.Green; }));
			}
			else
			{
				lblConnectionState.Text = "Online";
				lblConnectionState.ForeColor = Color.Green;
			}
		}

		private void SetConnectionDown()
		{
			if (lblConnectionState.InvokeRequired)
			{
				lblConnectionState.Invoke(new MethodInvoker(delegate { lblConnectionState.Text = "Offline"; }));
				lblConnectionState.Invoke(new MethodInvoker(delegate { lblConnectionState.ForeColor = Color.Red; }));
			}
			else
			{
				lblConnectionState.Text = "Offline";
				lblConnectionState.ForeColor = Color.Red;
			}
		}

		private void SetModemUp()
		{
			if (lblModemState.InvokeRequired)
			{
				lblModemState.Invoke(new MethodInvoker(delegate { lblModemState.Text = "Reachable"; }));
				lblModemState.Invoke(new MethodInvoker(delegate { lblModemState.ForeColor = Color.Green; }));
			}
			else
			{
				lblConnectionState.Text = "Reachable";
				lblConnectionState.ForeColor = Color.Green;
			}
		}

		private void SetModemDown()
		{
			if (lblModemState.InvokeRequired)
			{
				lblModemState.Invoke(new MethodInvoker(delegate { lblModemState.Text = "Unreachable"; }));
				lblModemState.Invoke(new MethodInvoker(delegate { lblModemState.ForeColor = Color.Red; }));
			}
			else
			{
				lblModemState.Text = "Unreachable";
				lblModemState.ForeColor = Color.Red;
			}
		}
		#endregion Private Methods
	}
}