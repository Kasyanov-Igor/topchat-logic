using System;
using System.Linq;
using TopChat.Models.Entities;
using TopChat.Services.Interfaces;

namespace TopChat.Services
{
	public class UserService : IUserServes
	{
		private ADatabaseConnection _db;

		public UserService(ADatabaseConnection db)
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

		public User? GetUser(string login)
		{
			return this._db.Users.Where(u => u.Login == login).FirstOrDefault();
		}
	}
}
