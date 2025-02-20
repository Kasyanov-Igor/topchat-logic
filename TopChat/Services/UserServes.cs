using System;
using System.Linq;
using TopChat.Models;
using TopChat.Models.Domains;
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

		public bool Registration(User user)
		{
			try
			{
				if (!this.FindUser(user))
				{

					this._db.Users.Add(user);
					this._db.SaveChanges();

					return true;

				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.ToString());
			}

			return false;
		}

		public bool FindUser(User user)
		{
			try
			{
				if (this._db.Users.Any(usr =>
				usr.Login == user.Login &&
				usr.Password == user.Password))
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

		public bool AddContact(User user, UserContact contact)
		{

			foreach (var userdb in this._db.Users)
			{
				if (userdb.Login == user.Login)
				{
					if (userdb.Contacts == null)
					{
						this._db.Users.Remove(userdb);

						user.Contacts.Add(contact);

						this.Registration(user);
					}
					else if (!userdb.Contacts.Any(u => u.UserName == contact.UserName))
					{
						userdb.Contacts.Add(contact);
					}
					else
					{
						Console.WriteLine("Такой contact уже существует. Пожалуйста, придумайте новый.");

						return false;
					}
				}
			};

			this._db.SaveChanges();

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
