namespace WaveTech.CMWatcher.Model.Interfaces.Services
{
	public interface IPingService
	{
		PingResponse Ping(string address, int numberOfPings);
	}
}