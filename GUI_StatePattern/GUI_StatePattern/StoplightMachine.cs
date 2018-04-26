using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_StatePattern
{
    public class StoplightMachine
    {
        private StoplightGreenState stoplightGreen;
        private StoplightYellowState stoplightYellow;
        private StoplightRedState stoplightRed;

        private IState state;

        public StoplightMachine()
        {
            StoplightGreen = new StoplightGreenState(this);
            StoplightYellow = new StoplightYellowState(this);
            StoplightRed = new StoplightRedState(this);

            State = stoplightRed;
        }

        public StoplightGreenState StoplightGreen { get => stoplightGreen; set => stoplightGreen = value; }
        public StoplightYellowState StoplightYellow { get => stoplightYellow; set => stoplightYellow = value; }
        public StoplightRedState StoplightRed { get => stoplightRed; set => stoplightRed = value; }
        public IState State { get => state; set => state = value; }
    }
}
