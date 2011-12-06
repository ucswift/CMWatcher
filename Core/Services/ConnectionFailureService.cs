using System.Collections.Generic;
using System.Linq;
using WaveTech.CMWatcher.Model;
using WaveTech.CMWatcher.Model.Interfaces.Repositories;
using WaveTech.CMWatcher.Model.Interfaces.Services;

namespace WaveTech.CMWatcher.Services
{
	public class ConnectionFailureService : IConnectionFailureService
	{
		private readonly IConnectionFailureRepository connectionFailureRepository;

		public ConnectionFailureService(IConnectionFailureRepository connectionFailureRepository)
		{
			this.connectionFailureRepository = connectionFailureRepository;
		}

		public List<ConnectionFailure> GetAllConnectionFailures()
		{
			return connectionFailureRepository.GetAllConnectionFailures().ToList();
		}

		public void SaveConnectionFailure(ConnectionFailure connectionFailure)
		{
			connectionFailureRepository.SaveConnectionFailure(connectionFailure);
		}

		public void DeleteAllConnectionFailures()
		{
			connectionFailureRepository.DeleteAllConnectionFailures();
		}
	}
}