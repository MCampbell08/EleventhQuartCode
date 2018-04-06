using System;
using System.Collections.Generic;
using System.Text;

namespace Ducks
{
    public class MallardDuck : Duck
    {
        public MallardDuck() : base(new RegularFlightBehavior())
        {
        }
    }
}
