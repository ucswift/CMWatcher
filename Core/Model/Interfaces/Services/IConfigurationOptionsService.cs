namespace WaveTech.CMWatcher.Model.Interfaces.Services
{
	public interface IConfigurationOptionsService
	{
		ConfigurationOptions GetConfiguration();
		void SaveConfiguration(ConfigurationOptions configurationOptions);
	}
}