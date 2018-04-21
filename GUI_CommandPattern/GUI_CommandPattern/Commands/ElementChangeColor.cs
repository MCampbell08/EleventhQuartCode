using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_CommandPattern.Commands
{
    public class ElementChangeColor : ICommand
    {
        public Vendors.LabelElement LabelElement { get; private set; }
        private string red = "", green = "", blue = "";
        public ElementChangeColor(Vendors.LabelElement labelElement, string red, string green, string blue)
        {
            LabelElement = labelElement;
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
        public void Execute()
        {
            LabelElement.ChangeColor(red, green, blue);
        }
        public void SetLabelElement(Vendors.LabelElement labelElement)
        {
            LabelElement = labelElement ?? throw new NullReferenceException("LabelElement object cannot be null.");
        }
        public void Undo()
        {
            LabelElement.ColorList.RemoveAt(LabelElement.ColorList.Count - 1);
            LabelElement.ChangeColor(LabelElement.ColorList[LabelElement.ColorList.Count - 1][0], LabelElement.ColorList[LabelElement.ColorList.Count - 1][1], LabelElement.ColorList[LabelElement.ColorList.Count - 1][2]);
        }
    }
}
