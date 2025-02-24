using System.Text;
using TopChat.Models.Domains;
using TopChat.Models.Entities;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class NetworkDataService : INetworkDataService
	{
		private IConnectionProvider _connectionProvider;

		public NetworkDataService(IConnectionProvider connectionProvider)
		{
			this._connectionProvider = connectionProvider;
		}

		public bool Send(NetworkData networkData)
		{
			this._connectionProvider.SetDestination(networkData.DestinationIP, networkData.DestinationPort);
			return this._connectionProvider.Send(networkData.Data);
		}

		public NetworkData Get(NetworkData request)
		{
			return  new NetworkData();
		}

		public NetworkData CreateRequest(User entity, SendType sendType)
		{
			NetworkData networkData = new NetworkData();

			string data;

			switch (sendType)
			{
				case SendType.Create:

					data = $"get|{entity.Login}|{entity.Password}";
					networkData.Data = Encoding.UTF8.GetBytes(data);

					break;
				case SendType.Delete:

					break;
				case SendType.Update:

					break;
				case SendType.Read:

					data = $"read|{entity.Login}|{entity.Password}";
					networkData.Data = Encoding.UTF8.GetBytes(data);

					break;
			}

			return networkData;
		}
	}
}
