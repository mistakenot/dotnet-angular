using System;
using Server.Data;
using Server.Models;

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
        }

        public void Apply(ApplicationDbContext db)
        {
            db.Accounts.Add(Account_1);
            db.EmailAddresses.Add(EmailAddress_1);
            db.SaveChanges();
        }

    }

    public class DatasetFixture
    {


    }
}
