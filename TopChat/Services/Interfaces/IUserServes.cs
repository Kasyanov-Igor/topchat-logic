using TopChat.Models;
using TopChat.Models.Domains;

namespace TopChat.Services.Interfaces
{
	public interface IUserServes
	{
		public bool Registration(User user);

		public bool FindUser(User user);

		public bool AddContact(User user, UserContact contact);

		public bool DeleteContact(User user, UserContact contact);

		public bool RenameContact(User user, UserContact contactOld, UserContact contactNew);

	}
}
