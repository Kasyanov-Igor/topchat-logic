using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TopChat.Models.Entities;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class ConnectionProviderUdp : IConnectionProvider
	{
		private UdpClient _udpClient;

		private IPEndPoint _IPEndPoint;

		private ADatabaseConnection _connection;

		public ConnectionProviderUdp()
		{
			this._udpClient = new UdpClient();

			this._connection = new SqliteConnection();
		}

		public bool SetDestination(string destinationIP, int destinationPort)
		{
			this._IPEndPoint = new IPEndPoint(IPAddress.Parse(destinationIP), destinationPort);
			return true;
		}

		public bool Send(byte[] data)
		{
			this._udpClient.Send(data, data.Length, this._IPEndPoint);

			return true;
		}

		public IPEndPoint GetIPEndPoint()
		{
			return this._IPEndPoint;
		}


		public async void StartReceive()
		{
			try
			{
				while (true)
				{
					//IPEndPoint remoteEP = null;
					//this._udpClient = new UdpClient(5000);

					//UdpReceiveResult receivedResults = _udpClient.ReceiveAsync().Result;
					//byte[] receivedBytes = receivedResults.Buffer;

					UdpClient u = new UdpClient(5000);

					UdpReceiveResult receivedResults = u.ReceiveAsync().Result;
					byte[] receivedBytes = receivedResults.Buffer;

					//receivedBytes = _udpClient.Receive(ref remoteEP);
					string[] messageDate = Encoding.UTF8.GetString(receivedBytes).Split('|');

					SaveMessageToDatabase(messageDate);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка: {ex.Message}");
			}
			finally
			{
				this._udpClient.Close();
			}
		}

		private void SaveMessageToDatabase(string[] messageDate)
		{
			IUserServes userServes = new UserService(this._connection);

			Message message = new Message()
			{
				MediaData = new Media() { Text = messageDate[0] },
				Sender = userServes.GetUser(messageDate[1]),
				Recipient = userServes.GetUser(messageDate[2]),
				DateTime = Convert.ToDateTime(messageDate[3])
			};

			this._connection.Messages.Add(message);
			this._connection.SaveChanges();
		}
	}
}
