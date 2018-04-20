using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_CommandPattern.Commands
{
    public class ElementMoveRight : ICommand
    {
        public Vendors.LabelElement LabelElement { get; private set; }
        public ElementMoveRight(Vendors.LabelElement labelElement)
        {
            LabelElement = labelElement;
        }
        public void Execute()
        {
            LabelElement.MoveRight();
        }
        public void SetLabelElement(Vendors.LabelElement labelElement)
        {
            LabelElement = labelElement ?? throw new NullReferenceException("LabelElement object cannot be null.");
        }

        public void Undo()
        {
            LabelElement.MoveLeft();
        }
    }
}
