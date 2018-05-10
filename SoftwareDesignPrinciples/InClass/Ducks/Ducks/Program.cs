using System;
using System.Collections.Generic;

namespace Ducks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            List<Duck> ducks = new List<Duck>();

            while (true)
            {
                int selector = random.Next(0, 2);
                if (ducks.Count < 5)
                {
                    switch (selector)
                    {
                        case 0:
                            ducks.Add(new MallardDuck());
                            break;
                        case 1:
                            ducks.Add(new SteamerDuck());
                            break;
                    }
                }
                foreach (Duck duck in ducks) {
                    Console.WriteLine(duck.GetType().ToString());
                    
                }
            }
        }
    }
}
