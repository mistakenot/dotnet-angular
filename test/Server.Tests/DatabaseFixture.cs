using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Xunit;

namespace Server.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public readonly MockDatabaseFactory DatabaseFactory;

        public DatabaseFixture()
        {
            DatabaseFactory = new MockDatabaseFactory();
        }

        public void Dispose()
        {
            DatabaseFactory.Dispose();
        }
    }

    public class MockDatabaseFactory : IDbFactory, IDisposable
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private readonly List<Action<ApplicationDbContext>> _actions;

        public MockDatabaseFactory()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase()
                .Options;
            _actions = new List<Action<ApplicationDbContext>>();

            ClearDb();
        }

        public ApplicationDbContext Create()
        {
            var db = new ApplicationDbContext(_dbContextOptions);
            _actions.ForEach(a => a(db));
            db.SaveChanges();
            return db;
        }

        public MockDatabaseFactory WithData(Action<ApplicationDbContext> seed)
        {
            _actions.Add(seed);
            return this;
        }

        public void Dispose()
        {
            ClearDb();
        }

        private void ClearDb()
        {
            using (var db = new ApplicationDbContext(_dbContextOptions))
            {
                Console.WriteLine("CLEARING");
                db.Database.EnsureDeleted();
                db.SaveChanges();
            }
        }
    }

    public class MockDatabaseFactoryTests
    {
        [Fact]
        public void CreateEntity()
        {
            using (var _factory = new MockDatabaseFactory())
            {
                var db = _factory.Create();
                var account = new Account() { Email = "123" };

                db.Accounts.Add(account);
                db.SaveChanges();

                var db2 = _factory.Create();
                var result = db2.Accounts.Single();

                Assert.NotNull(result);
                Assert.NotEqual(default(int), result.Id);
                Assert.Equal("123", result.Email);
            }
        }

        [Fact]
        public void MemoryTest()
        {
            using (var _factory = new MockDatabaseFactory())
            {
                var db = _factory.Create();
                db.Database.EnsureDeleted();
                db.SaveChanges();

                Assert.Equal(0, db.Accounts.Count());

                db.Accounts.Add(new Account());
                db.SaveChanges();

                Assert.Equal(1, db.Accounts.Count());
            }

            using (var _factory = new MockDatabaseFactory())
            {
                var db2 = _factory.Create();

                Assert.Equal(0, db2.Accounts.Count());
            }
        }
    }
}
