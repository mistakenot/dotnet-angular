using System.Threading.Tasks;
using Xunit;
using Server.Services;
using System.Linq;

namespace Server.Tests.Services
{
    public class InboxServiceTests : IClassFixture<DatabaseFixture>
    {
        private DatabaseFixture dbFactory;
        private InboxService inboxService;

        public InboxServiceTests(DatabaseFixture dbFactory)
        {
            this.dbFactory = dbFactory.WithBasicData();
            inboxService = new InboxService(dbFactory);
        }

        [Fact]
        public async Task CanGetEmailContent()
        {
            var actual = await inboxService.GetEmailContent(1);
            Assert.NotNull(actual);
            Assert.Equal("content", actual.Content);
        }

        [Fact]
        public async Task CanGetEmailHeader()
        {
            var actual = await inboxService.GetEmailHeaders(2, 10, 0);
            Assert.NotEmpty(actual);
            Assert.Equal(1, actual.Count());
        }
    }
}
