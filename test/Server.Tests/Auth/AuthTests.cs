using System.Threading.Tasks;
using Xunit;

namespace Server.Tests
{
    public class AuthTests : IntegrationTest
    {
        public AuthTests(
            ServerInstanceFixture server,
            HttpClientFixture client)
            : base(server, client)
        {

        }

        [Fact]
        public async Task CanLogin()
        {
            await Client.LoginAsync();
        }

        [Fact]
        public async Task CanLogout()
        {
            //await Client.LogoutAsync();
        }
    }
}
