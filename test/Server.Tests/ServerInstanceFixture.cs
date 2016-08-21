using System;
using Server;

namespace Server.Tests
{
    public class ServerInstanceFixture : IDisposable
    {
        private readonly Host _host;

        public ServerInstanceFixture()
        {
            _host = new Host();
        }

        public void Start()
        {
            _host.Start();
        }

        public void Dispose()
        {
            _host.Dispose();
        }
    }
}
