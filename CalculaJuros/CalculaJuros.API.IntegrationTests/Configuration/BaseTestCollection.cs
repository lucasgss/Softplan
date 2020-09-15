using Xunit;

namespace CalculaJuros.API.IntegrationTests.Configuration
{
    [CollectionDefinition("Base collection")]
    public abstract class BaseTestCollection : ICollectionFixture<BaseTestFixture>
    {
    }
}
