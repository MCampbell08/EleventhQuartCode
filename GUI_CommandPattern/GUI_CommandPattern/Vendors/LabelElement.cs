using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace GUI_CommandPattern.Vendors
{
    public class LabelElement
    {
        private const double ELEMENT_MOVEMENT_AMOUNT = 5;
        private Label label = new Label();
        public List<string[]> ColorList = new List<string[]>();
        public LabelElement(Label label)
        {
            this.label = label;
        }
        public void MoveUp()
        {
            label.Margin = new System.Windows.Thickness(label.Margin.Left, label.Margin.Top - ELEMENT_MOVEMENT_AMOUNT, label.Margin.Right, label.Margin.Bottom + ELEMENT_MOVEMENT_AMOUNT);
        }
        public void MoveDown()
        {
            label.Margin = new System.Windows.Thickness(label.Margin.Left, label.Margin.Top + ELEMENT_MOVEMENT_AMOUNT, label.Margin.Right, label.Margin.Bottom - ELEMENT_MOVEMENT_AMOUNT);
        }
        public void MoveLeft()
        {
            label.Margin = new System.Windows.Thickness(label.Margin.Left - ELEMENT_MOVEMENT_AMOUNT, label.Margin.Top, label.Margin.Right + ELEMENT_MOVEMENT_AMOUNT, label.Margin.Bottom);
        }
        public void MoveRight()
        {
            label.Margin = new System.Windows.Thickness(label.Margin.Left + ELEMENT_MOVEMENT_AMOUNT, label.Margin.Top, label.Margin.Right - ELEMENT_MOVEMENT_AMOUNT, label.Margin.Bottom);
        }
        public void ChangeColor(string red, string green, string blue)
        {
            if (ColorList.Count == 0)
                ColorList.Add(new string[] { "255", "255", "255" });
            ColorList.Add(new string[] { red, green, blue });
            label.Background = new SolidColorBrush(Color.FromRgb(byte.Parse(red), byte.Parse(green), byte.Parse(blue)));
        }
    }
}
