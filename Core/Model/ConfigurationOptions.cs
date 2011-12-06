namespace WaveTech.CMWatcher.Model
{
	public class ConfigurationOptions
	{
		public long ConfigurationOptionId { get; set; }

		// Modem Information
		public string ModemIPAddress { get; set; }
		public string ModemSignalPageUrl { get; set; }
		public string ModemLogPageUrl { get; set; }
		public string ModemUsername { get; set; }
		public string ModemPassword { get; set; }

		// Program Options
		public string MonitorAddress { get; set; }
		public string Profile { get; set; }
	}
}