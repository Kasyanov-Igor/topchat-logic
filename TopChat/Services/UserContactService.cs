using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using TopChat.Models.Entities;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class UserContactService
	{
		private ADatabaseConnection _connectiondb;

		public UserContactService(ADatabaseConnection aDatabase)
		{
			this._connectiondb = aDatabase;
		}

		public bool AddContact(UserContact contact)
		{
			UserService u = new UserService(this._connectiondb);
			contact.user = u.GetUser(contact.user.Login);
			try
			{
				if (!this.FindContact(contact))
				{
					this._connectiondb.UserContacts.Add(contact);
					this._connectiondb.SaveChanges();

					return true;
				}
			}
			
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}
		public bool FindContact(UserContact contact)
		{
			try
			{
				if (this._connectiondb.UserContacts.Any(a => a.UserName == contact.UserName && a.user.Login == contact.user.Login))
				{
					return true;

				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

	}
}
