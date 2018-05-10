using System;
using System.Collections.Generic;
using System.Text;

namespace StatePattern
{
    // STATES
    // - Empty
    // - Full - No Quarter
    // - Full - W/ Quarter
    // - No quarter
    //

    // TRANSITIONS
    // - Insert Quarter
    // - Turn Crank
    // - Take gumball
    // - Refill

    public class GumballMachine
    {
        private OutOfGumballState outOfGumball;
        private FullWithNoQuarterState fullWithNoQuarter;
        private FullWithQuarterState fullWithQuarter;
        private DispensingState dispensing;

        private IState state;

        public GumballMachine()
        {
            outOfGumball = new OutOfGumballState(this);
            fullWithNoQuarter = new FullWithNoQuarterState(this);
            fullWithQuarter = new FullWithQuarterState(this);
            dispensing = new DispensingState(this);

            State = FullWithNoQuarter;
        }

        public OutOfGumballState OutOfGumball { get => outOfGumball; set => outOfGumball = value; }
        public FullWithNoQuarterState FullWithNoQuarter { get => fullWithNoQuarter; set => fullWithNoQuarter = value; }
        public FullWithQuarterState FullWithQuarter { get => fullWithQuarter; set => fullWithQuarter = value; }
        public DispensingState Dispensing { get => dispensing; set => dispensing = value; }
        public IState State { get => state; set => state = value; }
    }
}
