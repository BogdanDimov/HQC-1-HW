using Task_1._Class_Chef_in_CS.Enums;
using Task_1._Class_Chef_in_CS.Models;

namespace Task_1._Class_Chef_in_CS.Contracts
{
    public interface IChef
    {
        Vegetable GetVegetable(VegetableType type);

        void Peel(Vegetable vegetable);

        void Cut(Vegetable vegetable);

        Bowl GetBowl();

        void Cook();
    } 
}