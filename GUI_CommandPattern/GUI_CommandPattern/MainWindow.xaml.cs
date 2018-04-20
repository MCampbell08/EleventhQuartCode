using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GUI_CommandPattern.Commands;

namespace GUI_CommandPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GUIController guiController = new GUIController();
        private Vendors.LabelElement classLabelElement;
        public MainWindow()
        {
            InitializeComponent();
            classLabelElement = new Vendors.LabelElement(labelElement);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W || e.Key == Key.Up)
                guiController.ExecuteGUICommand(new ElementMoveUp(classLabelElement));
            else if (e.Key == Key.A || e.Key == Key.Left)
                guiController.ExecuteGUICommand(new ElementMoveLeft(classLabelElement));
            else if (e.Key == Key.S || e.Key == Key.Down)
                guiController.ExecuteGUICommand(new ElementMoveDown(classLabelElement));
            else if (e.Key == Key.D || e.Key == Key.Right)
                guiController.ExecuteGUICommand(new ElementMoveRight(classLabelElement));
        }
        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            guiController.UndoRecentGUICommand();
        }
    }
}
