using System;
using System.Net;

namespace Training.Common
{
	public interface IUdpServer : IOpenable
	{
		int Port { get; set; }

		void Send(IPEndPoint Remote, byte[] Data);

		event Action<IUdpMessage> UdpMessageRx;
	}
}
