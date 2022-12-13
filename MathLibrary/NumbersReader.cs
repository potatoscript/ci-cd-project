namespace MathLibrary;

public interface IReaderBase
{
    Task<IEnumerable<int>> ReadNumbers();
}
internal class NumbersReader: IReaderBase
{
    public async Task<IEnumerable<int>> ReadNumbers()
    {
        var fileContent = await File.ReadAllTextAsync("numbers.txt");
        return fileContent.Split(',').Select(valueText => int.Parse(valueText));
    }

}
