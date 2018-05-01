using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace GUI_StatePattern
{
    public class StoplightYellowState : IState
    {
        private StoplightMachine stoplightMachine;

        public StoplightYellowState(StoplightMachine stoplightMachine)
        {
            this.stoplightMachine = stoplightMachine;
        }

        public void TurnLightGreen(Ellipse ellipse)
        {
            Console.WriteLine("Stoplight can't turn green if it is yellow.");
        }

        public void TurnLightRed(Ellipse ellipse)
        {
            stoplightMachine.State = stoplightMachine.StoplightRed;
            Console.WriteLine("Stoplight has turned red.");
        }

        public void TurnLightYellow(Ellipse ellipse)
        {
            Console.WriteLine("Stoplight can't turn yellow if it is yellow.");
        }
    }
}
