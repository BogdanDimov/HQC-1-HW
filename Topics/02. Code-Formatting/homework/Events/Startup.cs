using System;
using Events.Core;
using Events.Models;

namespace Events
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            while (Engine.ExecuteNextCommand())
            {
                Console.WriteLine(Messages.Output);
            }
        }
    }
}
