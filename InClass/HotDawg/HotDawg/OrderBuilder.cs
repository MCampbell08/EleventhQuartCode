using System;
using System.Collections.Generic;
using System.Text;

namespace HotDawg
{
    public class OrderBuilder
    {
        public void Run()
        {
            List<Dawg> order = new List<Dawg>
            {
                new Relish(new Ketchup(new BeefDawg()))
            };

            foreach (Dawg dawg in order)
            {
                Console.WriteLine(dawg.Cost());
            }
        }
    }
}
