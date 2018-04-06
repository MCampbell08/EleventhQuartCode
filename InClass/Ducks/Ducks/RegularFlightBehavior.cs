using System;
using System.Collections.Generic;
using System.Text;

namespace Ducks
{
    public class RegularFlightBehavior : FlyingBehavior
    {
        public void Perform()
        {
            Console.WriteLine("I can fly!");
        }
    }
}
