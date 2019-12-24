using System;
using System.Net;

namespace Training.Common
{
	public class UdpMessage
	{
		public IPEndPoint SrcEndpoint { get; set; }
		public byte [] Data { get; set; }
	}

	public interface IUdpServer
	{
		bool IsOpen { get; }

		void Open();

		void Close();

		void Send(IPEndPoint Remote, byte[] Data);

		event Action<UdpMessage> UdpMessageRx;
	}
}
