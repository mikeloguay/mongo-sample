namespace MongoConsole.Test;

public class CustomerRepositoryTest(MongoFixture fixture) : IClassFixture<MongoFixture>
{
    private readonly MongoFixture _fixture = fixture;

    [Fact]
    public async Task Insert_Find_OK()
    {
        await _fixture.Repository.InsertOne(new Customer { Id = 1, Name = "Customer 1"});
        Customer? customer = await _fixture.Repository.FindById(1);
        Assert.NotNull(customer);
    }
}
