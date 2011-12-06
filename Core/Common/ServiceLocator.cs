using StructureMap;

namespace WaveTech.CMWatcher.Common
{
	public static class ServiceLocator
	{
		public static T GetInstance<T>()
		{
			return ObjectFactory.GetInstance<T>();
		}
	}
}