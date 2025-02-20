using System.Collections.Generic;
using TopChat.Models.Domains;
using TopChat.Models.Entities;

namespace TopChat.Services.Interfaces
{
    public interface IDataConverterService
	{
		public NetworkData ConvertToNetworkData(Message fromEntity);

		public List<Message> ConvertFromNetworkData(NetworkData result);
    }
}
