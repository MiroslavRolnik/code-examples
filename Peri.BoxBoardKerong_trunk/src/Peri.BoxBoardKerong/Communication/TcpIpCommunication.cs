using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace P4U.Peri.BoxBoardKerong
{
	static class TcpIpCommunication
	{
		private static object Lock = new object();

		public static byte[] SendRequest(string ipAddress, int port, byte[] msg, bool hasResponse = false, int waitToResponseMiliseconds = 7000)
		{
			byte[] response = null;

			TcpClient client = null;

			DateTime endTime = DateTime.Now.AddMilliseconds(waitToResponseMiliseconds);

			bool isConnected = false;

			lock (Lock)
			{
				while (!isConnected)
				{
					try
					{
						client = new TcpClient();

						client.Connect(IPAddress.Parse(ipAddress), port);

						isConnected = true;

						NetworkStream stream = client.GetStream();
						try
						{
							stream.ReadTimeout = waitToResponseMiliseconds;

							stream.Write(msg, 0, msg.Length);

							if (hasResponse)
							{
								response = new byte[9];
								stream.Read(response, 0, response.Length);
							}
						}
						finally
						{
							Thread.Sleep(500);
							stream.Dispose();
						}
					}
					catch (Exception ex)
					{
						if (isConnected || DateTime.Now > endTime)
						{
							throw new Exception("TcpIpCommunication error.", ex);
						}
					}
					finally
					{
						client?.Dispose();
						Thread.Sleep(500);
					}
				}
			}

			return response;
		}
	}
}
