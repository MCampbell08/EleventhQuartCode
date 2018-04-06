using System;
using System.Collections.Generic;
using System.Text;

namespace HotDawg
{
    public class Mustard : Condiment
    {
        public Mustard(Dawg dawg) : base(HotDawg = dawg) { }
        public override double Cost()
        {
            return 0.05 + HotDawg.Cost();
        }
    }
}
