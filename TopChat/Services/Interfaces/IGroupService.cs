using TopChat.Models.Entities;

namespace TopChat.Services.Interfaces
{
    public interface IGroupService
	{
		public bool AddGroup(string name);

		public void AddUserToGroup(Group group, User userName);
	}
}
