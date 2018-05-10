using System;
using System.Collections.Generic;
using System.Text;

namespace HotDawg
{
    public abstract class Condiment : Dawg
    {

        public Condiment(Dawg dawg)
        {
            HotDawg = dawg;
        }

        public static Dawg HotDawg { get; set; }
        
    }
}
