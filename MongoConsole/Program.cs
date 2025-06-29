using MongoConsole;

CustomerRepository customerRepository = new("mongodb://mongouser:password1@localhost:27017/?authSource=admin");

int randomNumber = new Random().Next(1, 1000000);

Customer customerToInsert = new()
{
    Id = randomNumber,
    Name = $"Customer {randomNumber}",
};

await customerRepository.InsertOne(customerToInsert);

Customer? customer = await customerRepository.FindById(randomNumber);

if (customer is null)
{
    Console.WriteLine("Customer not found.");
    return;
}

Console.WriteLine(customer.Value);
