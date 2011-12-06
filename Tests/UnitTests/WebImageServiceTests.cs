using System;
using NUnit.Framework;
using WaveTech.CMWatcher.Services;

namespace UnitTests
{
	[TestFixture]
	public class WebImageServiceTests
	{
		[Test]
		public void TestUrlMakerWithUsernameAndPassword()
		{
			Uri page = WebImageService.FormatUrl("http://192.168.100.1/signal.htm", "user", "user");
			string test1 = page.AbsoluteUri;
		}

		[Test]
		public void TestUrlMakerWithoutAUsernameAndPassword()
		{
			Uri page = WebImageService.FormatUrl("http://192.168.100.1/signal.htm", null, null);
			string test1 = page.AbsoluteUri;
		}
	}
}