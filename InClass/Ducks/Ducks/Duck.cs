using System;
using System.Collections.Generic;
using System.Text;

namespace Ducks
{
    public abstract class Duck
    {
        private FlyingBehavior FlyingBehavior { get; set; }
        public Duck(FlyingBehavior flyingBehavior)
        {
            FlyingBehavior = flyingBehavior;
        }
        public void Swim()
        {
            Console.WriteLine("Yo, not drowning cause I can swim.");
        }
        public void Quack()
        {
            Console.WriteLine("Yo, I'm obnoxiously talking to you.");
        }
    }
}
