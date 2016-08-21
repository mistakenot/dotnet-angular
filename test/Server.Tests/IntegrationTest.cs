using System.Net.Http;
using Xunit;

namespace Server.Tests
{
    public abstract class IntegrationTest :
        IClassFixture<ServerInstanceFixture>,
        IClassFixture<HttpClientFixture>
    {
        protected HttpClient Client { get { return _client.Client; } }

        private readonly ServerInstanceFixture _server;
        private readonly HttpClientFixture _client;

        public IntegrationTest(
            ServerInstanceFixture serverInstanceFixture,
            HttpClientFixture httpClientFixture)
        {
            _client = httpClientFixture;
            _server = serverInstanceFixture;
            
            _server.Start();
        }
    }
}
