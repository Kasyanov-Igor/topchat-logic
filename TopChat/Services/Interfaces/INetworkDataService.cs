using TopChat.Models.Domains;
using TopChat.Models.Entities;

namespace TopChat.Services.Interfaces
{
    public interface INetworkDataService
	{
		public bool Send(NetworkData networkData);

        public NetworkData Get(NetworkData request);

		public NetworkData CreateRequest(User entity, SendType type);
    }
}
