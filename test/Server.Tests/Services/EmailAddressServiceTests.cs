using Server.Services;

namespace Server.Tests.Services
{
    public class EmailAddressServiceTests
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly EmailAddressService _service;

        public EmailAddressServiceTests(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
        }
    }
}
