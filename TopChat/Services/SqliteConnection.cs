using TopChat.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;

namespace TopChat.Services
{
    public class SqliteConnection : ADatabaseConnection
    {
		private static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
		{
            builder.AddConsole();
		});

		public const string _DATABASE_NAME = "../TopChat.db";

        protected override string ReturnConnectionString()
        {
            return $"Data Source={_DATABASE_NAME}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(this.ConnectionString)
                .UseLoggerFactory(MyLoggerFactory);
        }
	}
}
