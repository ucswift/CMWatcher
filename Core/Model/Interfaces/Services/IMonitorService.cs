using System;

namespace WaveTech.CMWatcher.Model.Interfaces.Services
{
	public interface IMonitorService
	{
		event EventHandler RequestStart;
		event EventHandler RequestStop;

		void MonitorInit(ConfigurationOptions configurationOptions);
		void OnStart();
		void OnStop();
	}
}