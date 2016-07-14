using System.Linq;
using System;
using Server.Data;
using Server.Models;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Server.Tests
{
    public interface IDataset
    {
        void Apply(ApplicationDbContext db);
    }

    public class Dataset : IDataset
    {
        public readonly Account Account_1;
        public readonly EmailAddress EmailAddress_1;
        public readonly EmailHeader EmailHeader_1;
        public readonly EmailContent EmailContent_1;

        public Dataset()
        {
            Account_1 = new Account()
            {
                Email = "bob@email.com"
            };

            EmailAddress_1 = new EmailAddress()
            {
                Address = "address1",
                Account = Account_1
            };

            EmailHeader_1 = new EmailHeader()
            {
                Account = Account_1,
                To = "to@email.com",
                From = "from@email.com",
                ContentSample = "I cannot do that for you Dave.",
                Subject = "Dave..."
            };

            EmailContent_1 = new EmailContent()
            {
                EmailHeader = EmailHeader_1,
                Content = "I cannot do that for you Dave. Dave. I cannot do that for you."
            };
        }

        public void Apply(ApplicationDbContext db)
        {
            Console.WriteLine("APPLYING");
            db.Accounts.Add(Account_1);
            db.EmailAddresses.Add(EmailAddress_1);
            db.EmailHeaders.Add(EmailHeader_1);
            db.EmailContents.Add(EmailContent_1);
            db.SaveChanges();

            Assert.Equal(1, db.Accounts.Count());
        }

    }

}
