using HumansCreator.Enumerations;

namespace HumansCreator.Contracts
{
    public interface IHuman
    {
        int Age { get; set; }

        Gender Gender { get; set; }

        string Name { get; set; }
    }
}