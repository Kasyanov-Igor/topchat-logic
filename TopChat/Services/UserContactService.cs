using TopChat.Services.Interfaces;

namespace TopChat.Services
{
    public class UserContactService : IUserContactService
    {
        private ADatabaseConnection _connectiondb;

        public UserContactService(ADatabaseConnection connectiondb)
        {
            this._connectiondb = connectiondb;
        }
        public bool AddContact(string name, string userIp, string userPort)
        {


            return true;
        }
    }
}
