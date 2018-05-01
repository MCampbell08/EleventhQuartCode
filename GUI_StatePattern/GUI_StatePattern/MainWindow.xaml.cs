using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_StatePattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double INTERTVAL = 1000;
        private Timer timer = new Timer(INTERTVAL);
        StoplightMachine stoplightMachine = new StoplightMachine();
        public MainWindow()
        {
            InitializeComponent();
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
            timer.Start();
            stoplightMachine.State = stoplightMachine.StoplightGreen;
        }
        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (stoplightMachine.State == stoplightMachine.StoplightGreen)
            {
                stoplightMachine.State = stoplightMachine.StoplightYellow;
                yellowLight.Fill = new SolidColorBrush(Colors.Yellow);
                greenLight.Fill = new SolidColorBrush(Colors.DarkGreen);
            }
            else if (stoplightMachine.State == stoplightMachine.StoplightYellow)
            {
                stoplightMachine.State = stoplightMachine.StoplightRed;
                redLight.Fill = new SolidColorBrush(Colors.Red);
                yellowLight.Fill = new SolidColorBrush(Colors.DarkKhaki);
            }
            else if (stoplightMachine.State == stoplightMachine.StoplightRed)
            {
                stoplightMachine.State = stoplightMachine.StoplightGreen;
                greenLight.Fill = new SolidColorBrush(Colors.Green);
                redLight.Fill = new SolidColorBrush(Colors.DarkRed);
            }
        }
    }
}
