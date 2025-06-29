using MongoDB.Driver;

namespace MongoConsole;

public interface ICustomerRepository
{
    Task InsertOne(Customer customer);
    Task<Customer?> FindById(int id);
}

public class CustomerRepository : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _collection;

    public CustomerRepository(string connectionString)
    {
        MongoClient client = new(connectionString);
        IMongoDatabase database = client.GetDatabase("management");
        _collection = database.GetCollection<Customer>("customers");
    }

    public async Task InsertOne(Customer customer) => 
        await _collection.InsertOneAsync(customer);

    public async Task<Customer?> FindById(int id)
    {
        FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}