using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUI_StatePattern
{
    public class StoplightGreenState : IState
    {
        private StoplightMachine stoplightMachine;

        public StoplightGreenState(StoplightMachine stoplightMachine)
        {
            this.stoplightMachine = stoplightMachine;
        }

        public void TurnLightGreen(Ellipse ellipse, Ellipse prevEllipse)
        {
            Console.WriteLine("Nope");
        }

        public void TurnLightRed(Ellipse ellipse, Ellipse prevEllipse)
        {
            Console.WriteLine("Nope");
        }

        public void TurnLightYellow(Ellipse ellipse, Ellipse prevEllipse)
        {
            ellipse.Fill = Brushes.Yellow;
            prevEllipse.Fill = Brushes.DarkGreen;
            stoplightMachine.State = stoplightMachine.StoplightYellow;
        }
    }
}
