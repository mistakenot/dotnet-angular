using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Server.Services;
using Server.Data;
using System;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using Newtonsoft.Json;

namespace Server.Tests.Services
{
    public class InboxServiceTests : IClassFixture<TestDbFactory>
    {
        private TestDbFactory dbFactory;
        private InboxService inboxService;

        public InboxServiceTests(TestDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            inboxService = new InboxService(dbFactory);

            var account = new Account();
            var emailHeader = new EmailHeader() { Account = account };
            var emailContent = new EmailContent()
            {
                Content = "content",
                EmailHeader = emailHeader
            };

            using (var db = dbFactory.Create())
            {
                db.EmailContents.Add(emailContent);
                db.SaveChanges();
            }
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
        }
    }
}
