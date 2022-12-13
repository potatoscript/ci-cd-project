namespace TestProject1;
public class TestBasicSytatics
{
    private class TestReader: IReaderBase
    {
        public Task<IEnumerable<int>> ReadNumbers() => 
            Task.FromResult(new[] { 1, 2 }.AsEnumerable());
    }

    [Fact]
    public async Task SumValueFromReader()
    {
        //var statistics = new BasicStatistics();
        var statistics = new BasicStatistics(new TestReader());
        var result = await statistics.SumValueFromReader();
        Assert.Equal(3,result);
    }
}