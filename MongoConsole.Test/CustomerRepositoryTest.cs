namespace MongoConsole.Test;

public class CustomerRepositoryTest : IClassFixture<MongoFixture>
{
    private readonly MongoFixture _fixture;

    public CustomerRepositoryTest(MongoFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Insert_Find_OK()
    {
        await _fixture.Repository.InsertOne(new Customer { Id = 1, Name = "Customer 1"});
        Customer? customer = await _fixture.Repository.FindById(1);
        Assert.NotNull(customer);
    }
}
