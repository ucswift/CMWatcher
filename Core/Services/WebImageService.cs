using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using mshtml;
using WaveTech.CMWatcher.Model.Interfaces.Services;

namespace WaveTech.CMWatcher.Services
{
	public class WebImageService : IWebImageService
	{
		public Image GetWebpageImage(string url, string username, string password)
		{
			if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
			{
				Image image = null;
				RunInSTAThread(() => image = RequestSnapshot(FormatUrl(url, username, password)));
				return image;
			}

			return RequestSnapshot(new Uri(url));
		}

		private static void RunInSTAThread(ThreadStart action)
		{
			var thread = new Thread(action)
			{
				Name = "CMWatcher.BrowserThread",
				IsBackground = true
			};
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
		}

		internal static Image RequestSnapshot(Uri url)
		{
			Image result = null;

			using (var completed = new AutoResetEvent(false))
			using (var browser = new WebBrowser())
			{
				browser.ScrollBarsEnabled = false;
				browser.DocumentCompleted += delegate
				{
					result = ExtractSnapshot(browser);
					completed.Set();
				};
				browser.Navigate(url);

				//completed.WaitOne();
				while (result == null)
				{
					Thread.Sleep(0);
					Application.DoEvents();
				}
			}

			return result;
		}

		internal static Image ExtractSnapshot(WebBrowser browser)
		{
			browser.ClientSize = new Size(850, 1500);

			Rectangle bounds = browser.Document.Body.ScrollRectangle;
			IHTMLElement2 body = browser.Document.Body.DomElement as IHTMLElement2;
			IHTMLElement2 doc = (browser.Document.DomDocument as IHTMLDocument3).documentElement as IHTMLElement2;
			int scrollHeight = Math.Max(body.scrollHeight, bounds.Height);
			int scrollWidth = Math.Max(body.scrollWidth, bounds.Width);
			scrollHeight = Math.Max(body.scrollHeight, scrollHeight);
			scrollWidth = Math.Max(doc.scrollWidth, scrollWidth);
			Rectangle finalBounds = new Rectangle(0, 0, scrollWidth, scrollHeight);

			browser.ClientSize = finalBounds.Size;
			var bitmap = new Bitmap(scrollWidth, scrollHeight);
			browser.BringToFront();
			browser.DrawToBitmap(bitmap, finalBounds);

			return bitmap;
		}

		internal static Uri FormatUrl(string url, string username, string password)
		{
			StringBuilder fullUrl = new StringBuilder();
			string tempUrl = url.Replace("http://", "");

			fullUrl.Append("http://");

			if (String.IsNullOrEmpty(username) == false)
			{
				fullUrl.Append(username);
				fullUrl.Append(":");
			}

			if (String.IsNullOrEmpty(password) == false)
			{
				fullUrl.Append(password);
				fullUrl.Append("@");
			}

			fullUrl.Append(tempUrl);
			return new Uri(fullUrl.ToString());
		}
	}
}