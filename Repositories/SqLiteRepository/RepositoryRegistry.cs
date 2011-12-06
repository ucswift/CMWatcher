using System.Data.EntityClient;
using System.Reflection;
using StructureMap.Attributes;
using StructureMap.Configuration.DSL;
using WaveTech.CMWatcher.Model.Interfaces.Repositories;

namespace WaveTech.CMWatcher.Repositories.SqLiteRepository
{
	public class RepositoryRegistry : Registry
	{
		internal static EntityConnectionStringBuilder EntityConntectionBuilder;

		protected override void configure()
		{
			string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
			path = path.Replace("file:\\", "");

			EntityConntectionBuilder = new EntityConnectionStringBuilder();
			EntityConntectionBuilder.Provider = "System.Data.SQLite";
			EntityConntectionBuilder.ProviderConnectionString = "data source=" + path + "\\CMWatcher.db";
			EntityConntectionBuilder.Metadata = "res://*/CMWatcherModel.csdl|res://*/CMWatcherModel.ssdl|res://*/CMWatcherModel.msl";

			string connectionString = EntityConntectionBuilder.ToString();

			ForRequestedType<CMWatcherEntities>().CacheBy(InstanceScope.Singleton).TheDefault.IsThis(new CMWatcherEntities(connectionString));
			ForRequestedType<IConfigurationOptionsRepository>().TheDefault.Is.OfConcreteType<ConfigurationOptionsRepository>();
			ForRequestedType<IConnectionFailureRepository>().TheDefault.Is.OfConcreteType<ConnectionFailureRepository>();
		}
	}
}