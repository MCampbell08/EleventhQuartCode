using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUI_StatePattern
{
    public class StoplightRedState : IState
    {
        private StoplightMachine stoplightMachine;

        public StoplightRedState(StoplightMachine stoplightMachine)
        {
            this.stoplightMachine = stoplightMachine;
        }

        public void TurnLightGreen(Ellipse ellipse, Ellipse prevEllipse)
        {
            ellipse.Fill = Brushes.Green;
            prevEllipse.Fill = Brushes.DarkRed;
            stoplightMachine.State = stoplightMachine.StoplightGreen;
        }

        public void TurnLightRed(Ellipse ellipse, Ellipse prevEllipse)
        {
            Console.WriteLine("Nope");
        }

        public void TurnLightYellow(Ellipse ellipse, Ellipse prevEllipse)
        {
            Console.WriteLine("Nope");
        }
    }
}
