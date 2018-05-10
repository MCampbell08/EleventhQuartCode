using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    public class FullWithQuarterState : IState
    {
        private GumballMachine gumballMachine;

        public FullWithQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Quarter is already in there.");
        }

        public void Refill()
        {
            Console.WriteLine("Can't refill when you're using it.");
        }

        public void TakeGumball()
        {
            Console.WriteLine("YOu need to turn the crank first.");
        }

        public void TurnCrank()
        {
            gumballMachine.State = gumballMachine.Dispensing;
            Console.WriteLine("You have turned the crank.");
        }
    }
}
