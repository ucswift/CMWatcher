using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using WaveTech.CMWatcher.Model;
using WaveTech.CMWatcher.Model.Interfaces.Services;

namespace WaveTech.CMWatcher.Services
{
	public class PingService : IPingService
	{
		public PingResponse Ping(string address, int numberOfPings)
		{
			using (Ping pingSender = new Ping())
			{
				PingOptions pingOptions = null;
				StringBuilder pingResults = null;
				PingReply pingReply = null;
				IPAddress ipAddress = null;
				int pingTimeout = 1000;
				int byteSize = 32;
				byte[] buffer = new byte[byteSize];
				int sentPings = 0;
				int receivedPings = 0;
				int lostPings = 0;
				long minPingResponse = 0;
				long maxPingResponse = 0;

				PingResponse pr = new PingResponse();

				pingOptions = new PingOptions();
				//pingOptions.DontFragment = true;
				//pingOptions.Ttl = 128;

				ipAddress = IPAddress.Parse(address);

				pingResults = new StringBuilder();
				pingResults.AppendLine(string.Format("Pinging {0} with {1} bytes of data:", ipAddress, byteSize));
				pingResults.AppendLine();

				for (int i = 0; i < numberOfPings; i++)
				{
					sentPings++;

					pingReply = pingSender.Send(ipAddress, pingTimeout, buffer, pingOptions);

					if (pingReply.Status == IPStatus.Success)
					{
						pingResults.AppendLine(string.Format("Reply from {0}: bytes={1} time={2}ms TTL={3}", ipAddress, byteSize, pingReply.RoundtripTime, pingReply.Options.Ttl));

						if (minPingResponse == 0)
						{
							minPingResponse = pingReply.RoundtripTime;
							maxPingResponse = minPingResponse;
						}
						else if (pingReply.RoundtripTime < minPingResponse)
						{
							minPingResponse = pingReply.RoundtripTime;
						}
						else if (pingReply.RoundtripTime > maxPingResponse)
						{
							maxPingResponse = pingReply.RoundtripTime;
						}

						receivedPings++;
					}
					else
					{
						pingResults.AppendLine(pingReply.Status.ToString());
						lostPings++;
					}
				}

				pingResults.AppendLine();
				pingResults.AppendLine(string.Format("Ping statistics for {0}:", ipAddress));
				pingResults.AppendLine(string.Format("\tPackets: Sent = {0}, Received = {1}, Lost = {2}", sentPings, receivedPings, lostPings));
				pingResults.AppendLine("Approximate round trip times in milli-seconds:");
				pingResults.AppendLine(string.Format("\tMinimum = {0}ms, Maximum = {1}ms", minPingResponse, maxPingResponse));

				pr.FailureCount = lostPings;
				pr.Data = pingResults.ToString();

				return pr;
			}
		}
	}
}