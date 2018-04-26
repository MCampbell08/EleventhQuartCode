using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_StatePattern
{
    public interface IState
    {
        void TurnLightGreen();
        void TurnLightYellow();
        void TurnLightRed();
    }
}
