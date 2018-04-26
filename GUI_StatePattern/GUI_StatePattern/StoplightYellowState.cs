using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_StatePattern
{
    public class StoplightYellowState : IState
    {
        private StoplightMachine stoplightMachine;

        public StoplightYellowState(StoplightMachine stoplightMachine)
        {
            this.stoplightMachine = stoplightMachine;
        }

        public void TurnLightGreen()
        {
            Console.WriteLine("Stoplight can't turn green if it is yellow.");
        }

        public void TurnLightRed()
        {
            stoplightMachine.State = stoplightMachine.StoplightRed;
            Console.WriteLine("Stoplight has turned red.");
        }

        public void TurnLightYellow()
        {
            Console.WriteLine("Stoplight can't turn yellow if it is yellow.");
        }
    }
}
