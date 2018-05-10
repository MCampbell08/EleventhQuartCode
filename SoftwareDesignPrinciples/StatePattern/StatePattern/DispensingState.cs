using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    public class DispensingState : IState
    {
        private GumballMachine gumballMachine;

        public DispensingState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("In the middle of dispensing.");
        }

        public void Refill()
        {
            Console.WriteLine("Can't refill when dispensing.");
        }

        public void TakeGumball()
        {
            gumballMachine.State = gumballMachine.FullWithNoQuarter;
            Console.WriteLine("You have taken the gumball.");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Cannot turn crank, need to take gumball. ");
        }
    }
}
