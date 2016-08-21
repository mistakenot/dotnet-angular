using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Server
{
    public class Host : IDisposable
    {
        private readonly IWebHost _host;
        private Task _task;
        private bool _disposed;

        public Host()
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();

            _host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            _disposed = false;
        }

        public void Start()
        {
            if (_task == null)
            {
                _task = Task.Run(() => _host.Run());
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _host.Dispose();
                _disposed = true;
            }
        }
    }
}
