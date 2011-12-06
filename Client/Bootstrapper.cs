using StructureMap;
using WaveTech.CMWatcher.Common;
using WaveTech.CMWatcher.Repositories.SqLiteRepository;
using WaveTech.CMWatcher.Services;

namespace WaveTech.CMWatcher.Client
{
	public static class Bootstrapper
	{
		public static void Configure()
		{
			ObjectFactory.Initialize(x =>
			{
				x.UseDefaultStructureMapConfigFile = false;

				x.AddRegistry(new CommonRegistry());
				x.AddRegistry(new RepositoryRegistry());
				x.AddRegistry(new ServicesRegistry());
			});
		}
	}
}