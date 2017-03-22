using System.Collections.Generic;
using Task_1._Class_Chef_in_CS.Contracts;

namespace Task_1._Class_Chef_in_CS.Models
{
    public class Bowl : IBowl
    {
        public Bowl()
        {
            this.Vegetables = new List<IVegetable>();
        }

        public IList<IVegetable> Vegetables { get; }

        public void Add(IVegetable veg)
        {
            this.Vegetables.Add(veg);
        }
    }
}
