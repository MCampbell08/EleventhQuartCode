using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    public class FullWithNoQuarterState : IState
    {
        private GumballMachine gumballMachine;

        public FullWithNoQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            gumballMachine.State = gumballMachine.FullWithQuarter;
            Console.WriteLine("You just instered a quarter.");
        }

        public void Refill()
        {
            Console.WriteLine("Machine is already full.");
        }

        public void TakeGumball()
        {
            Console.WriteLine("Stop theif!!!");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You need to insert a quarter first.");
        }
    }
}
