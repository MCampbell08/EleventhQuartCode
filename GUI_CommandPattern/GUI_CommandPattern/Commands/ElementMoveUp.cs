using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_CommandPattern.Commands
{
    public class ElementMoveUp : ICommand
    {
        public Vendors.LabelElement LabelElement { get;  private set; }
        public ElementMoveUp(Vendors.LabelElement labelElement)
        {
            LabelElement = labelElement;
        }
        public void Execute()
        {
            LabelElement.MoveUp();
        }
        public void SetLabelElement(Vendors.LabelElement labelElement)
        {
            LabelElement = labelElement ?? throw new NullReferenceException("LabelElement object cannot be null.");
        }
        public void Undo()
        {
            LabelElement.MoveDown();
        }
    }
}
