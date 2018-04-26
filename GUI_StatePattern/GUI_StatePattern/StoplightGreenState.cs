using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_StatePattern
{
    public class StoplightGreenState : IState
    {
        private StoplightMachine stoplightMachine;

        public StoplightGreenState(StoplightMachine stoplightMachine)
        {
            this.stoplightMachine = stoplightMachine;
        }

        public void TurnLightGreen()
        {
            Console.WriteLine("Stoplight can't turn green if it is green.");
        }

        public void TurnLightRed()
        {
            Console.WriteLine("Stoplight can't turn red if it is green.");
        }

        public void TurnLightYellow()
        {
            stoplightMachine.State = stoplightMachine.StoplightYellow;
            Console.WriteLine("Stoplight has turned yellow.");
        }
    }
}
