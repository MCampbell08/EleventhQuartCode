using System;
using System.Collections.Generic;
using System.Text;

namespace HotDawg
{
    public class Ketchup : Condiment
    {
        public Ketchup(Dawg dawg) : base(HotDawg = dawg) { }

        public override double Cost()
        {
            return 0.10 + HotDawg.Cost();
        }
    }
}
