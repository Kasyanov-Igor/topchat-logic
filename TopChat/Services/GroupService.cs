﻿using TopChat.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
using TopChat.Models.Entities;

namespace TopChat.Services
{
    public class GroupService : IGroupService
	{
		public bool AddGroup(string name)
		{
			try
			{
				Group group = new Group
				{
					Name = name,
					Users = new List<User>()
				};
				// _AllGroups.Add(group);
				return true;
			}
			catch (Exception exception)
			{
				// Log exception.Message;
				return false;
			}
		}

		public void AddUserToGroup(Group group, User user)
		{
			if (!group.Users.Any(a => a.Id == user.Id))
			{
				group.Users.Add(user);
			}
		}
	}
}
