using System;
using System.Collections.Generic;
using HumansCreator.Models;

public class Test
{
    public static void Main()
    {
        var firstHuman = Creator.CreateNewHuman(33);
        var secondHuman = Creator.CreateNewHuman(44);
        var humans = new List<Human>();
        humans.Add(firstHuman);
        humans.Add(secondHuman);

        foreach (var human in humans)
        {
            Console.WriteLine($"Name: {human.Name} Age: {human.Age} Gender: {human.Gender}");
        }
    }
}
