using System;
using System.Collections.Generic;
using System.Text;

namespace HotDawg
{
    public class Ketchup : Condiment
    {
        Dawg dawg;
        public Ketchup(Dawg dawg) : base(dawg) { this.dawg = dawg; }

        public override double Cost()
        {
            return 0.10 + dawg.Cost();
        }
    }
}
