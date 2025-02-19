using TopChat.Models;

namespace TopChat.Services.Interfaces
{
	public interface IUserServes
	{
		public bool Registration(string login, string password);

		public bool FindUser(string login);

		public bool AddContact(User user, UserContact contact);

		public bool DeleteContact(User user, UserContact contact);

		public bool RenameContact(User user, UserContact contactOld, UserContact contactNew);

	}
}
