using MongoConsole;

CustomerRepository customerRepository = new("mongodb://mongouser:password1@localhost:27017/?authSource=admin");

Customer c1 = new()
{
    Id = 1,
    Name = "Customer 1",
};

await customerRepository.InsertOne(c1);

Customer? customer = await customerRepository.FindById(1);

if (customer is null)
{
    Console.WriteLine("Customer not found.");
    return;
}

Console.WriteLine(customer.Id);
