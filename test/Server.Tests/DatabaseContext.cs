using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Server.Data;

namespace Server.Tests
{
    public class TestApplicationDbContext : ApplicationDbContext
    {
        private static readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        static TestApplicationDbContext()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase()
                .Options;
        }

        public TestApplicationDbContext()
            : base(_dbContextOptions)
        {

        }
    }

    public class TestDbFactory : IDbFactory, IDisposable
    {
        public ApplicationDbContext Create()
        {
            return new TestApplicationDbContext();
        }

        public void Dispose()
        {
            using (var db = new TestApplicationDbContext())
            {
                db.Database.EnsureDeleted();
                db.SaveChanges();
            }
        }

        public void DumpToConsole()
        {
            using (var db = new TestApplicationDbContext())
            {
                Write(db.Accounts);
                Write(db.EmailAddresses);
                Write(db.EmailHeaders);
                Write(db.EmailContents);
            }
        }

        private void Write(IEnumerable<object> write)
        {
            Console.WriteLine(write.GetType().ToString());

            foreach (var obj in write)
            {
                Console.WriteLine(JsonConvert.SerializeObject(obj));
            }
        }
    }
}
