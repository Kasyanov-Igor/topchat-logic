using System.Collections.Generic;
using TopChat.Models.Domains;

namespace TopChat.Models
{
    public class User
	{
		public int Id { get; set; }

		public string Login { get; set; } = null!;

		public string Password { get; set; } = null!;

		public List<UserContact>? Contacts { get; set; } 
	}
}
