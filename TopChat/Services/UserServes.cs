using System;
using System.Diagnostics.Contracts;
using System.Linq;
using DnsClient;
using TopChat.Models;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class UserServes : IUserServes
	{
		private ADatabaseConnection _db;

		public UserServes(ADatabaseConnection db)
		{
			this._db = db;
		}

		public bool Registration(string login, string password)
		{
			if (this._db.Users.Any(u => u.Login == login))
			{
				Console.WriteLine("Такой логин уже существует. Пожалуйста, придумайте новый.");
				return false;
			}

			User user = new User()
			{
				Login = login,
				Password = password,
			};

			this._db.Users.Add(user);
			this._db.SaveChanges();

			return true;
		}

		public bool FindUser(string login)
		{
			if (this._db.Users.Any(u => u.Login == login))
			{
				return true;
			}

			return false;
		}

		public bool AddContact(User user, UserContact contact)
		{
			//if(user.Contacts == null)
			//{
			//             user.Contacts.Add(contact);

			//             return true;
			//         }
			if (user.Contacts.Any(u => u.UserName == contact.UserName))
			{
				Console.WriteLine("Такой contact уже существует. Пожалуйста, придумайте новый.");

				return false;
			}

			user.Contacts.Add(contact);

			return true;
		}

		public bool DeleteContact(User user, UserContact contact)
		{
			if (user.Contacts.Any(u => u.UserName != contact.UserName))
			{
				Console.WriteLine("There is no contact");
				return false;
			}

			user.Contacts.Remove(contact);

			return true;
		}

		public bool RenameContact(User user, UserContact contactOld, UserContact contactNew)
		{
			if (user.Contacts.Any(u => u.UserName != contactOld.UserName))
			{
				Console.WriteLine("There is no contact");

				user.Contacts.Remove(contactOld);
				user.Contacts.Add(contactNew);

				return true;
			}

			return false;
		}

	}
}
