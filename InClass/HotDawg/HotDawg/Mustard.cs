using System;
using System.Collections.Generic;
using System.Text;

namespace HotDawg
{
    public class Mustard : Condiment
    {
        Dawg dawg;
        public Mustard(Dawg dawg) : base(dawg) { this.dawg = dawg; }
        public override double Cost()
        {
            return 0.05 + dawg.Cost();
        }
    }
}
