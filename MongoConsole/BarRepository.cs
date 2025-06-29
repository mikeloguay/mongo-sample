using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoConsole;

public interface IBarRepository
{
    Task InsertOne(BsonDocument document);
    Task<List<BsonDocument>> Find(FilterDefinition<BsonDocument> filter);
}

public class BarRepository : IBarRepository
{
    private readonly IMongoCollection<BsonDocument> _collection;

    public BarRepository(string connectionString)
    {
        MongoClient client = new(connectionString);
        IMongoDatabase database = client.GetDatabase("foo");
        _collection = database.GetCollection<BsonDocument>("bar");
    }
    
    public async Task InsertOne(BsonDocument document) => await _collection.InsertOneAsync(document);
    
    public async Task<List<BsonDocument>> Find(FilterDefinition<BsonDocument> filter)
    {
        IAsyncCursor<BsonDocument> docs = await _collection.FindAsync(filter);
        return docs.ToList();
    }
}