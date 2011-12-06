using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WaveTech.CMWatcher.Services;

namespace TestHarness
{
	class Program
	{
		static void Main(string[] args)
		{
			TestWebImageCapture();
		}

		public static void TestWebImageCapture()
		{
			WebImageService wis = new WebImageService();
			//Image bm1 = wis.GetWebpageImage("http://www.yahoo.com");

			Image bm1 = wis.GetWebpageImage("http://192.168.100.1/cmSignal.htm", null, null);
			bm1.Save("G:\\test1.bmp");
		}
	}
}
