using System;
using System.Linq;
using WaveTech.CMWatcher.Model.Interfaces.Repositories;

namespace WaveTech.CMWatcher.Repositories.SqLiteRepository
{
	public class ConfigurationOptionsRepository : IConfigurationOptionsRepository
	{
		private readonly CMWatcherEntities db;

		public ConfigurationOptionsRepository(CMWatcherEntities db)
		{
			this.db = db;
		}

		public IQueryable<Model.ConfigurationOptions> GetConfiguration()
		{
			return from co in db.ConfigurationOptions
						 select new Model.ConfigurationOptions
						 {
							 ConfigurationOptionId = co.ConfigurationOptionId,
							 ModemIPAddress = co.ModemIPAddress,
							 ModemSignalPageUrl = co.ModemSignalPageUrl,
							 ModemLogPageUrl = co.ModemLogPageUrl,
							 ModemUsername = co.ModemUsername,
							 ModemPassword = co.ModemPassword,
							 MonitorAddress = co.MonitorAddress,
							 Profile = co.Profile
						 };
		}

		public void SaveConfiguration(Model.ConfigurationOptions configurationOptions)
		{
			using (CMWatcherEntities dbContainer = new CMWatcherEntities(RepositoryRegistry.EntityConntectionBuilder.ToString()))
			{
				if (configurationOptions.ConfigurationOptionId == 0)
				{
					ConfigurationOptions co = new ConfigurationOptions();

					co.ModemIPAddress = configurationOptions.ModemIPAddress;
					co.ModemSignalPageUrl = configurationOptions.ModemSignalPageUrl;
					co.ModemLogPageUrl = configurationOptions.ModemLogPageUrl;
					co.ModemUsername = configurationOptions.ModemUsername;
					co.ModemPassword = configurationOptions.ModemPassword;
					co.MonitorAddress = configurationOptions.MonitorAddress;
					co.Profile = configurationOptions.Profile;

					dbContainer.AddToConfigurationOptions(co);
				}
				else
				{
					var co = (from co1 in dbContainer.ConfigurationOptions
									 where co1.ConfigurationOptionId == configurationOptions.ConfigurationOptionId
									 select co1).First();

					co.ModemIPAddress = configurationOptions.ModemIPAddress;
					co.ModemSignalPageUrl = configurationOptions.ModemSignalPageUrl;
					co.ModemLogPageUrl = configurationOptions.ModemLogPageUrl;
					co.ModemUsername = configurationOptions.ModemUsername;
					co.ModemPassword = configurationOptions.ModemPassword;
					co.MonitorAddress = configurationOptions.MonitorAddress;
					co.Profile = configurationOptions.Profile;
				}

				dbContainer.SaveChanges();
			}
		}
	}
}