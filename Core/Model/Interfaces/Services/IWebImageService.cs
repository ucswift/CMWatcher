using System.Drawing;

namespace WaveTech.CMWatcher.Model.Interfaces.Services
{
	public interface IWebImageService
	{
		Image GetWebpageImage(string url, string username, string password);
	}
}