using System.Collections.Generic;

namespace Task_1._Class_Chef_in_CS.Contracts
{
    public interface IBowl
    {
        IList<IVegetable> Vegetables { get; }

        void Add(IVegetable veg);
    }
}