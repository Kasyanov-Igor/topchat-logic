using TopChat.Models.Entities;

namespace TopChat.Services.Interfaces
{
    public interface IUserServes
	{
		public User? GetUser(string login);

		public bool Registration(User user);

		public bool FindUser(User user);
	}
}
