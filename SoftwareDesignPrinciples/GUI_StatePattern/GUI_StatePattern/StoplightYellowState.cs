using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
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

        public void TurnLightGreen(Ellipse ellipse, Ellipse prevEllipse)
        {
            Console.WriteLine("Nope");
        }

        public void TurnLightRed(Ellipse ellipse, Ellipse prevEllipse)
        {
            ellipse.Fill = Brushes.Red;
            prevEllipse.Fill = Brushes.DarkKhaki;
            stoplightMachine.State = stoplightMachine.StoplightRed;
        }

        public void TurnLightYellow(Ellipse ellipse, Ellipse prevEllipse)
        {
            Console.WriteLine("Nope");
        }
    }
}
