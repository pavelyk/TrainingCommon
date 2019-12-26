using System;
using System.Net;

namespace Training.Common
{
	/// <summary>
	/// Applicatin UDP Server.
	/// </summary>
	public interface IAppUdpServer 
		: IUdpServer
	{
		event Action<IAppMessage> AppMessageRx;

		void Send(IPEndPoint Remote, IAppMessage Data);
	}

	/// <summary>
	/// OTA (Over-the-air) App Message Structure:
	/// 
	///     0  -  3          4 - 5         6 .. N-2    n-2 n-1
	/// [    MsgId    ] [ Message Type ] [ Message ] [ MSB LSB ]
	/// 
	/// MsgId        - Message Id
	/// Message Type - 
	/// Message      - Message
	/// CRC16_CCITT  - 2-byte CRC calculated using TrainingUtils.CRC16_CCITT.
	/// 
	/// </summary>
	public interface IAppMessage 
		: IUdpMessage
	{
		/// <summary>
		/// Message ID to map response to its request.
		/// </summary>
		int MsgId { get; set; }

		/// <summary>
		/// Message type.
		/// </summary>
		AppMessageType MessageType { get; set; }
	}

	/// <summary>
	/// Message Type
	/// </summary>
	public enum AppMessageType
	{
		Text
	}
}
