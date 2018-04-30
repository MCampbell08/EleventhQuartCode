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
        private const double INTERTVAL = 3000;
        private Timer timer = new Timer(INTERTVAL);
        public MainWindow()
        {
            InitializeComponent();
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }
        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if(timer.Interval >= INTERTVAL)
            {

            }
        }

        public enum LightState{
            GREEN,
            YELLOW,
            RED
        }
    }
}
