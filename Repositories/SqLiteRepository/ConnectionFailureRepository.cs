using System.Linq;
using WaveTech.CMWatcher.Model;
using WaveTech.CMWatcher.Model.Interfaces.Repositories;

namespace WaveTech.CMWatcher.Repositories.SqLiteRepository
{
	public class ConnectionFailureRepository : IConnectionFailureRepository
	{
		private readonly CMWatcherEntities db;

		public ConnectionFailureRepository(CMWatcherEntities db)
		{
			this.db = db;
		}

		public IQueryable<ConnectionFailure> GetAllConnectionFailures()
		{
			return from cf in db.ConnectionFailures
						 select new Model.ConnectionFailure
											{
												ConnectionFailureId = cf.ConnectionFailureId,
												StartTimestamp = cf.StartTimestamp,
												EndTimestamp = cf.EndTimestamp,
												ScreenShotsPath = cf.ScreenShotsPath,
												Data = cf.Data
											};
		}

		public void SaveConnectionFailure(Model.ConnectionFailure connectionFailure)
		{
			using (CMWatcherEntities dbContainer = new CMWatcherEntities(RepositoryRegistry.EntityConntectionBuilder.ToString()))
			{
				ConnectionFailures cf = new ConnectionFailures();

				cf.ConnectionFailureId = connectionFailure.ConnectionFailureId;
				cf.StartTimestamp = connectionFailure.StartTimestamp;
				cf.EndTimestamp = connectionFailure.EndTimestamp;
				cf.ScreenShotsPath = connectionFailure.ScreenShotsPath;
				cf.Data = connectionFailure.Data;

				dbContainer.AddToConnectionFailures(cf);
				dbContainer.SaveChanges();
			}
		}

		public void DeleteAllConnectionFailures()
		{
			using (CMWatcherEntities dbContainer = new CMWatcherEntities(RepositoryRegistry.EntityConntectionBuilder.ToString()))
			{
				var entries = from cf in db.ConnectionFailures
											select cf;

				foreach (var e in entries)
					dbContainer.DeleteObject(e);
			}
		}
	}
}