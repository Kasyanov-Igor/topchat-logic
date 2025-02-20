using System.Collections.Generic;

namespace TopChat.Models.Domains
{
    public class UserContact
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;

        public string UserIp { get; set; } = null!;

        public string UserPort { get; set; } = null!;
    }
}
