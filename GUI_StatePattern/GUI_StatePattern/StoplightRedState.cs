using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_StatePattern
{
    public class StoplightRedState : IState
    {
        private StoplightMachine stoplightMachine;

        public StoplightRedState(StoplightMachine stoplightMachine)
        {
            this.stoplightMachine = stoplightMachine;
        }

        public void TurnLightGreen()
        {
            stoplightMachine.State = stoplightMachine.StoplightGreen;
            Console.WriteLine("Stoplight has turned green.");
        }

        public void TurnLightRed()
        {
            Console.WriteLine("Can't turn the stoplight red if it's already red.");
        }

        public void TurnLightYellow()
        {
            Console.WriteLine("Stoplight can't turn yellow if it is red.");
        }
    }
}
