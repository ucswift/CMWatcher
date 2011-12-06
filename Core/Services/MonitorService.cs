using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using WaveTech.CMWatcher.Common;
using WaveTech.CMWatcher.Model;
using WaveTech.CMWatcher.Model.Events;
using WaveTech.CMWatcher.Model.Interfaces.Services;
using WaveTech.CMWatcher.Services.Properties;

namespace WaveTech.CMWatcher.Services
{
	public class MonitorService : IMonitorService
	{
		#region Public Events
		public event EventHandler RequestStart;
		public event EventHandler RequestStop;
		#endregion Public Events

		#region Private Readonly Members
		private readonly IConnectionFailureService connectionFailureService;
		private readonly IPingService pingService;
		private readonly IWebImageService webImageService;
		private readonly IEventAggregator _eventAggregator;
		#endregion Private Readonly Members

		#region Private Members
		private bool _isWorking;
		private ConfigurationOptions _configurationOptions;
		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		#endregion Private Members

		#region Constructor
		public MonitorService(IConnectionFailureService connectionFailureService, IPingService pingService,
			IWebImageService webImageService, IEventAggregator eventAggregator)
		{
			this.connectionFailureService = connectionFailureService;
			this.pingService = pingService;
			this.webImageService = webImageService;
			_eventAggregator = eventAggregator;
		}
		#endregion Constructor

		#region Monitor Init
		public void MonitorInit(ConfigurationOptions configurationOptions)
		{
			if (Log.IsDebugEnabled) Log.Debug(Resources.Msg_Monitor_InitCalled);

			// Register interal event handlers for external events
			RequestStart += MonitorService_RequestStart;
			RequestStop += MonitorService_RequestStop;

			_configurationOptions = configurationOptions;
			_isWorking = false;

			if (Log.IsDebugEnabled) Log.Debug(Resources.Msg_Montior_InitFinished);
		}
		#endregion Monitor Init

		#region RunInSTAThread
		private static void RunInSTAThread(ThreadStart action)
		{
			var thread = new Thread(action)
			{
				Name = "CMWatcher.MonitorThread",
				IsBackground = true
			};
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}
		#endregion RunInSTAThread

		#region Public Event Handlers
		public void OnStart()
		{
			if (RequestStart != null) RequestStart(this, null);
		}

		public void OnStop()
		{
			if (RequestStop != null) RequestStop(this, null);
		}
		#endregion Public Event Handlers

		#region Private Envent Handlers
		private void MonitorService_RequestStop(object sender, EventArgs e)
		{
			_isWorking = false;
		}

		private void MonitorService_RequestStart(object sender, EventArgs e)
		{
			_isWorking = true;
			RunInSTAThread(Worker);
		}
		#endregion Private Envent Handlers

		#region Worker
		public void Worker()
		{
			if (Log.IsDebugEnabled) Log.DebugFormat(Resources.Msg_Monitor_WorkerStarted);

			ConnectionFailure cf = new ConnectionFailure();
			bool previousFailue = false;
			bool isModemLive = true;
			_eventAggregator.SendMessage<ConnectionUpEvent>();

			while (_isWorking)
			{
				PingResponse pr = pingService.Ping(_configurationOptions.MonitorAddress, 3);
				PingResponse prModem = pingService.Ping(_configurationOptions.ModemIPAddress, 3);

				if (prModem.FailureCount == 3)
				{
					_eventAggregator.SendMessage<ModemDownEvent>();
					isModemLive = false;
				}
				else
				{
					_eventAggregator.SendMessage<ModemUpEvent>();
					isModemLive = true;
				}

				if (pr.FailureCount == 3)
				{
					if (Log.IsDebugEnabled) Log.DebugFormat(Resources.Msg_Monitor_WorkerPingTimeout);
					_eventAggregator.SendMessage<ConnectionDownEvent>();

					if (!previousFailue)
					{
						previousFailue = true;
						cf.StartTimestamp = DateTime.Now;

						string path = null;

						if (isModemLive)
						{
							if (Log.IsDebugEnabled) Log.DebugFormat(Resources.Msg_Monitor_WorkerStartingModemPagesCapture);

							Image signalPage = null;
							Image logPage = null;

							try
							{
								signalPage = webImageService.GetWebpageImage(_configurationOptions.ModemSignalPageUrl,
																														 _configurationOptions.ModemUsername,
																														 _configurationOptions.ModemPassword);
								logPage = webImageService.GetWebpageImage(_configurationOptions.ModemLogPageUrl,
																													_configurationOptions.ModemUsername,
																													_configurationOptions.ModemPassword);
							}
							catch (Exception ex)
							{
								Log.ErrorFormat("============START CMWATCHER ERROR=============");
								Log.ErrorFormat(string.Format("Unable to capture images from the modem"));
								Log.ErrorFormat("Check to ensure CMWatcher can get to the modem paths and that they are correct.}");

								if (Log.IsDebugEnabled) Log.DebugFormat(ex.ToString());

								Log.ErrorFormat("============END CMWATCHER ERROR=============");
							}

							path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
							string dateDirectory = string.Format("{0}-{1}-{2}_{3}-{4}-{5}", DateTime.Now.Month, DateTime.Now.Day,
																									 DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute,
																									 DateTime.Now.Second);

							path = path + string.Format("\\images\\{0}", dateDirectory);

							try
							{
								Directory.CreateDirectory(path);

								if (signalPage != null)
									signalPage.Save(string.Format("{0}\\SignalPage.bmp", path));

								if (logPage != null)
									logPage.Save(string.Format("{0}\\LogPage.bmp", path));
							}
							catch (Exception ex)
							{
								Log.ErrorFormat("============START ERROR=============");
								Log.ErrorFormat(string.Format("Unable to create or save the images to path: {0}", path));
								Log.ErrorFormat("Check to ensure CMWatcher can write to that directory, or run CMWatcher as Administrator.}");

								if (Log.IsDebugEnabled) Log.DebugFormat(ex.ToString());

								Log.ErrorFormat("============END ERROR=============");
							}
						}
						else
						{
							Log.ErrorFormat("NOTICE: Modem is unreachable, not capturing images.");
						}

						if (Log.IsErrorEnabled)
						{
							Log.ErrorFormat(Resources.Msg_Monitor_WorkerConnectionErrorHeader);
							Log.ErrorFormat(pr.Data);

							if (!String.IsNullOrEmpty(path))
								Log.ErrorFormat(string.Format(Resources.Msg_Montior_WorkerSavingPath, path));
						}

						if (!String.IsNullOrEmpty(path))
							cf.ScreenShotsPath = path;
						else
							cf.ScreenShotsPath = String.Empty;

						cf.Data = pr.Data;
					}
					else
					{
						if (Log.IsDebugEnabled) Log.DebugFormat(Resources.Msg_Monitor_WorkerPreviousFailureDetectedSkip);
						_eventAggregator.SendMessage<ConnectionDownEvent>();
					}
				}
				else
				{
					if (Log.IsDebugEnabled) Log.DebugFormat(Resources.Msg_Monitor_WorkerPingSuccess);

					if (previousFailue)
					{
						if (Log.IsDebugEnabled) Log.DebugFormat(string.Format(Resources.Msg_Monitor_WorkerPreviousFailureDetected, cf.StartTimestamp, DateTime.Now));
						_eventAggregator.SendMessage<ConnectionUpEvent>();

						cf.EndTimestamp = DateTime.Now;
						connectionFailureService.SaveConnectionFailure(cf);

						previousFailue = false;
						cf = new ConnectionFailure();

						_eventAggregator.SendMessage<StatusUpdateEvent>();
					}
				}

				if (Log.IsDebugEnabled) Log.DebugFormat(string.Format(Resources.Msg_Monitor_WorkerThreadSleep, "1000"));
				Thread.Sleep(1000);
			}

			if (Log.IsDebugEnabled) Log.DebugFormat(Resources.Msg_Monitor_WorkerFinished);
		}
		#endregion Worker
	}
}