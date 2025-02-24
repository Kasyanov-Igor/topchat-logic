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

		public bool DeleteContact(string nameContact)
		{
			try
			{
				UserContact contact = this.GetContactUser(nameContact);

				if (contact != null)
				{
					if (!this.FindContact(contact))
					{
						this._connectiondb.UserContacts.Remove(contact);
						this._connectiondb.SaveChanges();

						return true;
					}
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

		public UserContact? GetContactUser(string login)
		{
			return this._connectiondb.UserContacts.Where(u => u.UserName == login).FirstOrDefault();
		}

	}
}
