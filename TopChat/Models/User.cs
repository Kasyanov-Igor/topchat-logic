using System.Collections.Generic;

namespace TopChat.Models
{
	public class User
	{
		public int Id { get; set; }

		public string Login { get; set; } = null!;

		public string Password { get; set; } = null!;

		public List<UserContact>? Contacts { get; set; } = new List<UserContact>();
	}
}
