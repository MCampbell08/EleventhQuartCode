using System;
using System.Collections.Generic;
using System.Text;

namespace HotDawg
{
     public class Relish : Condiment
    {
        Dawg dawg;
        public Relish(Dawg dawg) : base(dawg) { this.dawg = dawg; }
        
        public override double Cost()
        {
            return .20 + dawg.Cost();
        }
    }
}
