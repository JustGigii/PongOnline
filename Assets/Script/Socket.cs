using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System;


namespace Assets.Script
{
	 class Socket
	{
		static	TcpClient client;
		static	NetworkStream stream;
		static	Byte[] data;
		public static void Start()
		{
			Int32 port = 25565;
			string ip = "83.130.148.134";
			client = new TcpClient(ip, port);
			// Get a client stream for reading and writing.
			//  Stream stream = client.GetStream();
			stream = client.GetStream();
			// Close everything.
			//stream.Close();
			//client.Close();
		}
		public static void Send(string Message)
		{
			// Translate the passed message into ASCII and store it as a Byte array.
			data = System.Text.Encoding.ASCII.GetBytes(Message);

			

			// Send the message to the connected TcpServer. 
			stream.Write(data, 0, data.Length);

		}
		public static string Recv()
		{
			// Receive the TcpServer.response.

			// Buffer to store the response bytes.
			data = new Byte[1024];

			// String to store the response ASCII representation.
			String responseData = String.Empty;

			// Read the first batch of the TcpServer response bytes.
			Int32 bytes = stream.Read(data, 0, data.Length);
			responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
			return responseData;
		}

	}
}
