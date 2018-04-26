using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    public class OutOfGumballState : IState
    {
        private GumballMachine gumballMachine;

        public OutOfGumballState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            throw new NotImplementedException();
        }

        public void Refill()
        {
            throw new NotImplementedException();
        }

        public void TakeGumball()
        {
            throw new NotImplementedException();
        }

        public void TurnCrank()
        {
            throw new NotImplementedException();
        }
    }
}
