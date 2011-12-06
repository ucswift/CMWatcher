using System.Collections.Generic;

namespace WaveTech.CMWatcher.Model.Interfaces.Services
{
	public interface IConnectionFailureService
	{
		List<ConnectionFailure> GetAllConnectionFailures();
		void SaveConnectionFailure(ConnectionFailure connectionFailure);
		void DeleteAllConnectionFailures();
	}
}