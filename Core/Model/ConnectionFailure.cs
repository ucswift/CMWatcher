using System;

namespace WaveTech.CMWatcher.Model
{
	public class ConnectionFailure
	{
		public long ConnectionFailureId { get; set; }
		public DateTime StartTimestamp { get; set; }
		public DateTime EndTimestamp { get; set; }
		public string ScreenShotsPath { get; set; }
		public string Data { get; set; }
	}
}