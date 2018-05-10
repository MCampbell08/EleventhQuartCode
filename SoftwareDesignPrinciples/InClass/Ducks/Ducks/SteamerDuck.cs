using System;
using System.Collections.Generic;
using System.Text;

namespace Ducks
{
    public class SteamerDuck : Duck
    {
        public SteamerDuck() : base(new NonFlyingFlightBehavior()) { }
    }
}
