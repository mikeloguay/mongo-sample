using Testcontainers.MongoDb;

namespace MongoConsole.Test;

public class MongoFixture : IAsyncLifetime
{
    public required ICustomerRepository Repository { get; set; }
    private MongoDbContainer? _mongoDbContainer;

    public async Task InitializeAsync()
    {
        _mongoDbContainer = new MongoDbBuilder()
            .WithImage("mongo:latest")
            .Build();

        await _mongoDbContainer.StartAsync();
        Repository = new CustomerRepository(_mongoDbContainer.GetConnectionString());
    }

    public async Task DisposeAsync()
    {
        await _mongoDbContainer!.DisposeAsync();
    }
}
