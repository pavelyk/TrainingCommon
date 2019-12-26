using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Training.Common
{
	public interface IUdpMessage
	{
		IPEndPoint PeerEndpoint { get; set; }

		byte[] Data { get; set; }
	}
}
