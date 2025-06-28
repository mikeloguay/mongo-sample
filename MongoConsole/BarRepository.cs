using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoConsole;

public interface IBarRepository
{
    Task InsertOneAsync(BsonDocument document);
    List<BsonDocument> Find(FilterDefinition<BsonDocument> filter);
}

public class BarRepository(IMongoDatabase database) : IBarRepository
{
    private readonly IMongoCollection<BsonDocument> _collection = database.GetCollection<BsonDocument>("bar");
    
    public async Task InsertOneAsync(BsonDocument document) => await _collection.InsertOneAsync(document);
    public List<BsonDocument> Find(FilterDefinition<BsonDocument> filter) => _collection.Find(filter).ToList();
}