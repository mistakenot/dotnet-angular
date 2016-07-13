using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Tests
{
    public class DatabaseFixture
    {
        public readonly MockDatabaseFactory DatabaseFactory;

        public DatabaseFixture()
        {
            DatabaseFactory = new MockDatabaseFactory();
        }
    }

    public class MockDatabaseFactory : IDbFactory
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private readonly List<Action<ApplicationDbContext>> _actions;

        public MockDatabaseFactory()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase()
                .Options;
            _actions = new List<Action<ApplicationDbContext>>();
        }

        public ApplicationDbContext Create()
        {
            var db = new ApplicationDbContext(_dbContextOptions);
            _actions.ForEach(a => a(db));
            return db;
        }

        public MockDatabaseFactory WithData(Action<ApplicationDbContext> seed)
        {
            _actions.Add(seed);
            return this;
        }
    }
}
