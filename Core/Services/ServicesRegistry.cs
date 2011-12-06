using StructureMap.Configuration.DSL;
using WaveTech.CMWatcher.Model.Interfaces.Services;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace WaveTech.CMWatcher.Services
{
	public class ServicesRegistry : Registry
	{
		protected override void configure()
		{
			ForRequestedType<IConfigurationOptionsService>().TheDefault.Is.OfConcreteType<ConfigurationOptionsService>();
			ForRequestedType<IConnectionFailureService>().TheDefault.Is.OfConcreteType<ConnectionFailureService>();
			ForRequestedType<IMonitorService>().TheDefault.Is.OfConcreteType<MonitorService>();
			ForRequestedType<IPingService>().TheDefault.Is.OfConcreteType<PingService>();
			ForRequestedType<IWebImageService>().TheDefault.Is.OfConcreteType<WebImageService>();
		}
	}
}