using StructureMap.Attributes;
using StructureMap.Configuration.DSL;

namespace WaveTech.CMWatcher.Common
{
	public class CommonRegistry : Registry
	{
		protected override void configure()
		{
			ForRequestedType<IEventAggregator>().CacheBy(InstanceScope.Singleton).TheDefault.Is.OfConcreteType<EventAggregator>();
		}
	}
}