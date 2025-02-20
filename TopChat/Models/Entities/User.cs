using System.Collections.Generic;

namespace TopChat.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
