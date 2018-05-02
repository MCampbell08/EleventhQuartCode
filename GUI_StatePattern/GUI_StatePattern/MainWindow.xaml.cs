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
using System.Windows.Threading;

namespace GUI_StatePattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const long INTERVAL = 2000;
        private DispatcherTimer timer = new DispatcherTimer();
        StoplightMachine stoplightMachine = new StoplightMachine();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(INTERVAL);
            timer.Tick += OnTimedEvent;
            timer.IsEnabled = true;
            timer.Start();
            stoplightMachine.State = stoplightMachine.StoplightGreen;
        }
        public void OnTimedEvent(object source, EventArgs e)
        {
            int count = timer.Interval.Seconds;
            if (--count == 0) {
                if (stoplightMachine.State == stoplightMachine.StoplightGreen)
                {
                    stoplightMachine.State.TurnLightYellow(yellowLight, greenLight);
                }
                else if (stoplightMachine.State == stoplightMachine.StoplightYellow)
                {
                    stoplightMachine.State.TurnLightRed(redLight, yellowLight);
                }
                else if (stoplightMachine.State == stoplightMachine.StoplightRed)
                {
                    stoplightMachine.State.TurnLightGreen(greenLight, redLight);
                }
            }
            timer.Interval = TimeSpan.FromSeconds(count);
            if (timer.Interval.Seconds == 0)
            {
                timer.Interval = TimeSpan.FromMilliseconds(INTERVAL);
            }
        }

        private void ChangeLightButton_Click(object sender, RoutedEventArgs e)
        {
            if (greenLightButton == e.OriginalSource)
            {
                stoplightMachine.State.TurnLightYellow(yellowLight, greenLight);
            }
            else if (yellowLightButton == e.OriginalSource)
            {
                stoplightMachine.State.TurnLightRed(redLight, yellowLight);
            }
            else if (redLightButton == e.OriginalSource)
            {
                stoplightMachine.State.TurnLightGreen(greenLight, redLight);
            }
        }
    }
}
