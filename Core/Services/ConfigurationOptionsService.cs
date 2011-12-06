using System;
using System.Linq;
using WaveTech.CMWatcher.Model;
using WaveTech.CMWatcher.Model.Interfaces.Repositories;
using WaveTech.CMWatcher.Model.Interfaces.Services;

namespace WaveTech.CMWatcher.Services
{
	public class ConfigurationOptionsService : IConfigurationOptionsService
	{
		private readonly IConfigurationOptionsRepository configurationOptionsRepository;

		public ConfigurationOptionsService(IConfigurationOptionsRepository configurationOptionsRepository)
		{
			this.configurationOptionsRepository = configurationOptionsRepository;
		}

		public ConfigurationOptions GetConfiguration()
		{
			return configurationOptionsRepository.GetConfiguration().FirstOrDefault();
		}

		public void SaveConfiguration(ConfigurationOptions configurationOptions)
		{
			configurationOptionsRepository.SaveConfiguration(configurationOptions);
		}
	}
}