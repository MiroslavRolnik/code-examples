using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.Peri.BoxBoardKerong.BoxArrayImplementation
{
	public class Socket:IEquatable<Socket>
	{
		public string IpAddress { get; private set; }
		public int Port { get; private set; }

		public Socket(string ipAddress, int port)
		{
			IpAddress = ipAddress;
			Port = port;
		}
		public static Socket Parse(string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException();
			}

			string[] parts = text.Split(':');

			if (parts.Length == 2)
			{
				string ipAddress = parts[0];
				int port = int.Parse(parts[1]);

				return new Socket(ipAddress, port);
			}
			else
			{
				throw new Exception("Invalid text representation of socket!");
			}
		}

		public bool Equals(Socket socket)
		{
			if (socket == null)
			{
				return false;
			}

			return (IpAddress?.Equals(socket.IpAddress) == true) && Port.Equals(socket.Port);
		}

		public override bool Equals(object obj)
		{
			Socket socket = obj as Socket;

			if (socket == null)
			{
				return false;
			}

			return Equals(socket);
		}

		public override string ToString()
		{
			return $"{IpAddress}:{Port}";
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}
	}
}
