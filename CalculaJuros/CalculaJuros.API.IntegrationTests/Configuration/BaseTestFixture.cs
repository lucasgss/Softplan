using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CalculaJuros.API.IntegrationTests.Configuration
{
    public class BaseTestFixture : IDisposable
    {
        public readonly TestServer Server;
        public readonly HttpClient Client;
        //public readonly MainContext TestMainContext;
        public BaseTestFixture()
        {
            Server = new TestServer(
                WebHost.CreateDefaultBuilder()
                    .UseEnvironment("Testing")
                    .UseStartup<Startup>());

            Client = Server.CreateClient();

        }
        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
    }
}
