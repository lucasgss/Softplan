using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Xunit;

namespace CalculaJuros.API.IntegrationTests.Configuration
{
    [Collection("Base collection")]
    public abstract class BaseIntegrationTest
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        protected BaseTestFixture Fixture { get; }

        protected BaseIntegrationTest(BaseTestFixture fixture)
        {
            Fixture = fixture;

            Server = fixture.Server;
            Client = fixture.Client;

        }

    }
}
