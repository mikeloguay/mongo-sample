using MongoDB.Bson;
using MongoConsole;

BarRepository barRepository = new("mongodb://mongouser:password1@localhost:27017/?authSource=admin");

await barRepository.InsertOne(new BsonDocument("Name", "Pepe"));

var list = await barRepository.Find(new BsonDocument("Name", "Pepe"));

foreach (var document in list)
{
    Console.WriteLine(document["Name"]);
}