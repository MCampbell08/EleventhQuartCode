using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    public interface IState
    {
        void InsertQuarter();
        void TurnCrank();
        void TakeGumball();
        void Refill();
    }
}
