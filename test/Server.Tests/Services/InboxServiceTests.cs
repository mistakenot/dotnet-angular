using Xunit;

namespace Server.Tests.Services
{
    public class InboxServiceTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _databaseFixture;
        private static IDataset _dataset = new Dataset();

        public InboxServiceTests(
            DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _databaseFixture.DatabaseFactory.WithData(_dataset.Apply);
        }

    }
}
