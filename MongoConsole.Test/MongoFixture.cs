using Testcontainers.MongoDb;

namespace MongoConsole.Test;

public class MongoFixture : IAsyncLifetime
{
    public required MongoDbContainer MongoDbContainer { get; set; }
    public required ICustomerRepository Repository { get; set; }

    public async Task InitializeAsync()
    {
        MongoDbContainer = new MongoDbBuilder()
            .WithImage("mongo:latest")
            .Build();

        await MongoDbContainer.StartAsync();
        Repository = new CustomerRepository(MongoDbContainer.GetConnectionString());
    }

    public async Task DisposeAsync()
    {
        await MongoDbContainer.DisposeAsync();
    }
}
