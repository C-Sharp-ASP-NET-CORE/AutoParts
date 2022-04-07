using AutoParts.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Test
{
    public class InMemoryDbCOntext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<AutoPartsDbContext> dbContextOptions;

        public InMemoryDbCOntext()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<AutoPartsDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new AutoPartsDbContext(dbContextOptions);

            context.Database.EnsureCreated();
        }

        public AutoPartsDbContext CreateContext() 
            => new AutoPartsDbContext(dbContextOptions);

        public void Dispose()
            => connection.Dispose();
    }
}
