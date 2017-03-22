using System;

public class LoopRefactor
{
    private const int EXPECTED_VALUE = 666;

    public void SearchValue()
    {
        for (int i = 0; i < 100; i++)
        {
            if (i % 10 == 0)
            {
                if (array[i] == EXPECTED_VALUE)
                {
                    Console.WriteLine("Value Found");
                    break;
                }
                else
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}
