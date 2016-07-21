using Server.Models;

namespace Server.Tests
{
    public static class DatabaseFixtureExtensions
    {
        public static DatabaseFixture WithBasicData(this DatabaseFixture fixture)
        {
            var account = new Account();
            var emailHeader = new EmailHeader() { Account = account };
            var emailContent = new EmailContent()
            {
                Content = "content",
                EmailHeader = emailHeader
            };
            var emailAddress = new EmailAddress()
            {
                Account = account,
                Address = "address"
            };

            using (var db = fixture.Create())
            {
                db.EmailContents.Add(emailContent);
                db.EmailAddresses.Add(emailAddress);
                db.SaveChanges();
            }

            return fixture;
        }
    }
}
