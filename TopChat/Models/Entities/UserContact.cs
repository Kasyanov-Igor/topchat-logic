using System;

namespace TopChat.Models.Entities
{
    public class UserContact
    {
        public int Id { get; set; }

        public User user { get; set; } = null!;

		public string UserName { get; set; } = null!;

        public string UserIp { get; set; } = null!;

        public DateTime dateTime { get; set; }
    }
}
