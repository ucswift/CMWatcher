using System.Linq;

namespace WaveTech.CMWatcher.Model.Interfaces.Repositories
{
	public interface IConfigurationOptionsRepository
	{
		IQueryable<ConfigurationOptions> GetConfiguration();
		void SaveConfiguration(ConfigurationOptions configurationOptions);
	}
}