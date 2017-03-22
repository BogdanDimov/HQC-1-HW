using System;
using System.Text;
using Task_1._Class_Chef_in_CS.Contracts;
using Task_1._Class_Chef_in_CS.Enums;
using Task_1._Class_Chef_in_CS.Models;

public class Chef : IChef
{
    public void Peel(Vegetable vegetable)
    {
        Console.WriteLine("The " + vegetable.Type.ToString().ToLower() + " is now cut.");
    }

    public void Cut(Vegetable vegetable)
    {
        Console.WriteLine("The " + vegetable.Type.ToString().ToLower() + " is now peeled.");
    }

    public Vegetable GetVegetable(VegetableType type)
    {
        switch (type)
        {
            case VegetableType.Carrot:
                return new Carrot();
            case VegetableType.Potato:
                return new Potato();
            default:
                throw new InvalidOperationException("Unknown vegetable type.");
        }
    }

    public Bowl GetBowl()
    {
        var bowl = new Bowl();
        return bowl;
    }

    public void Cook()
    {
        Vegetable potato = GetVegetable(VegetableType.Potato);
        Peel(potato);
        Cut(potato);

        Vegetable carrot = GetVegetable(VegetableType.Carrot);
        Peel(carrot);
        Cut(carrot);

        Bowl bowl = GetBowl();
        bowl.Add(carrot);
        bowl.Add(potato);

        var sb = new StringBuilder();
        sb.Append("Bowl with ");
        foreach (var vegetable in bowl.Vegetables)
        {
            sb.Append($"{vegetable.Type.ToString().ToLower()} + ");
        }

        sb.Remove(sb.Length - 3, 3);
        sb.Append(" is now prepared!");
        Console.WriteLine(sb.ToString());
    }
}