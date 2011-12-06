using System.Linq;

namespace WaveTech.CMWatcher.Model.Interfaces.Repositories
{
	public interface IConnectionFailureRepository
	{
		IQueryable<ConnectionFailure> GetAllConnectionFailures();
		void SaveConnectionFailure(ConnectionFailure connectionFailure);
		void DeleteAllConnectionFailures();
	}
}