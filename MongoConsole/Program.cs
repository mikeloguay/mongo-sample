using MongoDB.Bson;
using MongoDB.Driver;
using MongoConsole;

MongoClient client = new("mongodb://mongouser:password1@localhost:27017/?authSource=admin");
IMongoDatabase database = client.GetDatabase("foo");
BarRepository barRepository = new(database);

await barRepository.InsertOneAsync(new BsonDocument("Name", "Pepe"));

var list = barRepository.Find(new BsonDocument("Name", "Pepe"));

foreach (var document in list)
{
    Console.WriteLine(document["Name"]);
}