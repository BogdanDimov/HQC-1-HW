using Task_1._Class_Chef_in_CS.Contracts;
using Task_1._Class_Chef_in_CS.Enums;

namespace Task_1._Class_Chef_in_CS.Models
{
    public class Vegetable : IVegetable
    {
        public Vegetable(VegetableType type)
        {
            this.Type = type;
        }

        public VegetableType Type { get; set; }
    }
}
