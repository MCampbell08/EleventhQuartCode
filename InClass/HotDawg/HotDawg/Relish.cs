using System;
using System.Collections.Generic;
using System.Text;

namespace HotDawg
{
     public class Relish : Condiment
    {
        public Relish(Dawg dawg) : base(HotDawg = dawg) { }
        
        public override double Cost()
        {
            return .20 + HotDawg.Cost();
        }
    }
}
