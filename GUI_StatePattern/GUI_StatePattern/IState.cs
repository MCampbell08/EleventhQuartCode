using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace GUI_StatePattern
{
    public interface IState
    {
        void TurnLightGreen(Ellipse ellipse);
        void TurnLightYellow(Ellipse ellipse);
        void TurnLightRed(Ellipse ellipse);
    }
}
