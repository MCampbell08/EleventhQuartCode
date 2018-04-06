using System;
using System.Collections.Generic;
using System.Text;

namespace Ducks
{
    public class NonFlyingFlightBehavior : FlyingBehavior
    {
        public void Perform()
        {
            Console.WriteLine("I am grounded!");
        }
    }
}
