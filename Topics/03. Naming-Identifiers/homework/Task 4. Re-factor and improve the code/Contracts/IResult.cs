namespace Minesweeper.Contracts
{
    public interface IResult
    {
        string Name { get; set; }

        int Points { get; set; }
    }
}