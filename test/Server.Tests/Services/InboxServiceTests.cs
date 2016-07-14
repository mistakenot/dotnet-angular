using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Server.Services;

namespace Server.Tests.Services
{
    public class InboxServiceTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly IInboxService _inboxService;
        private static Dataset _dataset = new Dataset();

        public InboxServiceTests(
            DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _databaseFixture.DatabaseFactory.WithData(_dataset.Apply);
            _inboxService = new InboxService(_databaseFixture.DatabaseFactory);
        }

        [Fact]
        public async Task CanGetEmailContent()
        {
            var model = _dataset.EmailContent_1;

            Assert.Equal(default(int), model.Id);
            Assert.Equal(1, _databaseFixture.DatabaseFactory.Create().Accounts.Count());
            var result = await _inboxService.GetEmailContent(2);

            Assert.NotNull(result);
            Assert.Equal(model.Content, result.Content);
            Assert.Equal(model.EmailHeader, result.EmailHeader);
        }

    }
}
