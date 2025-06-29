using Testcontainers.MongoDb;

namespace MongoConsole.Test;

public abstract class MongoDbContainerTest : IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDbContainer;

    private MongoDbContainerTest(MongoDbContainer mongoDbContainer)
    {
        _mongoDbContainer = mongoDbContainer;
    }

    public async Task InitializeAsync()
    {
        await _mongoDbContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _mongoDbContainer.StopAsync();
    }

    [Fact]
    public async Task ExecScriptReturnsSuccessful()
    {
        // Given
        const string scriptContent = "printjson(db.adminCommand({listDatabases:1,nameOnly:true,filter:{\"name\":/^admin/}}));";

        // When
        var execResult = await _mongoDbContainer.ExecScriptAsync(scriptContent)
            .ConfigureAwait(true);

        // Then
        Assert.True(0L.Equals(execResult.ExitCode), execResult.Stderr);
        Assert.Empty(execResult.Stderr);
    }

    public sealed class MongoDbDefaultConfiguration : MongoDbContainerTest
    {
        public MongoDbDefaultConfiguration()
            : base(new MongoDbBuilder().Build())
        {
        }
    }
}