namespace MathLibrary;
public class BasicStatistics
{
    private readonly IReaderBase reader;
    public BasicStatistics(IReaderBase reader)
    {
        this.reader = reader;
    }
    public async Task<int> SumValueFromReader()
    {
        //var reader = new NumbersReader();
        var numbers = await reader.ReadNumbers();
        return numbers.Sum();
    }
}
