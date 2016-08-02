using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services;
using Xunit;

namespace Server.Tests.Services
{
    public class EmailAddressServiceTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly EmailAddressService _service;

        public EmailAddressServiceTests(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture.WithBasicData();
            _service = new EmailAddressService(_databaseFixture);
        }

        [Fact]
        public async Task CreateAddress_Ok()
        {
            var randomAddress = new Random().Next().ToString();
            var created = await _service.CreateAddress(2, randomAddress);

            Assert.Equal(randomAddress, created.Address);
            Assert.Equal(2, created.AccountId);
        }

        [Fact]
        public async Task CreateDuplicateAddress_Fail()
        {
            var duplicateAddress = "address";

            var ex = await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _service.CreateAddress(2, duplicateAddress);
            });
        }

        [Fact]
        public async Task GetRecommendations_Ok()
        {
            List<string> existingRecommendations;
            using (var db = _databaseFixture.Create())
            {
                existingRecommendations = db.EmailAddresses
                    .Select(a => a.Address)
                    .ToList();
            }

            var recommendations = await _service.GetAddressRecommendations();

            foreach (var recommendation in recommendations)
            {
                Assert.DoesNotContain(recommendation, existingRecommendations);
            }

        }

    }
}
