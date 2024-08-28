using System.Data.Common;
using Dotnet.Samples.AspNetCore.WebApi.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Samples.AspNetCore.WebApi.Tests
{
    public static class PlayerStubs
    {
        public static (DbConnection, DbContextOptions<PlayerDbContext>) CreateSqliteConnection()
        {
            var dbConnection = new SqliteConnection("Filename=:memory:");
            dbConnection.Open();

            var dbContextOptions = new DbContextOptionsBuilder<PlayerDbContext>()
                .UseSqlite(dbConnection)
                .Options;

            return (dbConnection, dbContextOptions);
        }

        public static void CreateTable(PlayerDbContext dbContext)
        {
            using var dbCommand = dbContext.Database.GetDbConnection().CreateCommand();

            dbCommand.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS players
                (
                    id	            INTEGER,
                    firstName	    TEXT NOT NULL,
                    middleName      TEXT,
                    lastName	    TEXT NOT NULL,
                    dateOfBirth	    TEXT,
                    squadNumber	    INTEGER NOT NULL,
                    position        TEXT NOT NULL,
                    abbrPosition    TEXT,
                    team            TEXT,
                    league    	    TEXT,
                    starting11      BOOLEAN,
                    PRIMARY KEY(id)
                );";

            dbCommand.ExecuteNonQuery();
        }

        public static PlayerDbContext CreateDbContext(
            DbContextOptions<PlayerDbContext> dbContextOptions
        )
        {
            return new PlayerDbContext(dbContextOptions);
        }

        public static void SeedDbContext(PlayerDbContext dbContext)
        {
            dbContext.AddRange(PlayerFakes.CreateStarting11());
            dbContext.SaveChanges();
        }

        public static ModelStateDictionary CreateModelError(string key, string errorMessage)
        {
            var modelStateDictionary = new ModelStateDictionary();
            modelStateDictionary.AddModelError(key, errorMessage);
            return modelStateDictionary;
        }
    }
}
