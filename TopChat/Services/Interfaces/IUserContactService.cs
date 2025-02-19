using System;
using TopChat.Models;

namespace TopChat.Services.Interfaces
{
    public interface IUserContactService
    {
        public bool AddContact(string name, string userIp, string userPort);

    }
}
