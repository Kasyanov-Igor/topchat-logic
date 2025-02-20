using System.Collections.Generic;
using TopChat.Models.Domains;
using TopChat.Models.Entities;

namespace TopChat.Services.Interfaces
{
    public interface IMessageService
    {
        public bool AddMessage(Message message);

		public List<Message> GetMessages(User sender, SendType type);
    }
}
