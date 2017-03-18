using Minesweeper.Contracts;

namespace Minesweeper.Models
{
    public class Result : IResult
    {
        private string name;
        private int points;

        public Result()
        {
        }

        public Result(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }
    }
}
