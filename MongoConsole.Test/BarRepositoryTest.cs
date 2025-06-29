using MongoDB.Bson;
using Testcontainers.MongoDb;

namespace MongoConsole.Test;

public class BarRepositoryTest : IAsyncLifetime
{
    private readonly MongoDbContainer _container;
    private IBarRepository _barRepository;

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _container.DisposeAsync();
    }

    public BarRepositoryTest()
    {
        _container = new MongoDbBuilder()
            .WithImage("mongo:latest")
            .Build();
    }

    [Fact]
    public async Task Insert_Find_OK()
    {
        _barRepository = new BarRepository(_container.GetConnectionString());

        await _barRepository.InsertOne(new BsonDocument("Name", "Test"));
        List<BsonDocument> docs = await _barRepository.Find(new BsonDocument("Name", "Test"));
        Assert.NotEmpty(docs);
    }
}
