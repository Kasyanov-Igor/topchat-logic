﻿using Microsoft.EntityFrameworkCore;
using TopChat.Models.Domains;
using TopChat.Models.Entities;

namespace TopChat.Services.Interfaces
{
    public abstract class ADatabaseConnection : DbContext
	{
		protected abstract string ReturnConnectionString();

		protected string ConnectionString { get; private set; }

		public DbSet<User> Users => Set<User>();

		public DbSet<UserContact> UserContacts => Set<UserContact>();

		public DbSet<Group> Groups => Set<Group>();

		public DbSet<NetworkData> NetworkDatas => Set<NetworkData>();

		public DbSet<Media> Medias => Set<Media>();

		public DbSet<Message> Messages => Set<Message>();

		public ADatabaseConnection()
		{
			this.ConnectionString = this.ReturnConnectionString();

			this.Database.EnsureCreated();
		}
	}
}
