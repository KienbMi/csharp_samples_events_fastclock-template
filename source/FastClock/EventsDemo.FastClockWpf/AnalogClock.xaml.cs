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
using System.Windows.Shapes;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for AnalogClock.xaml
    /// </summary>
    public partial class AnalogClock : Window
    {
        private EventsDemo.FastClock.FastClock _fastClock;

        RotateTransform MinHandTr;
        RotateTransform HourHandTr;

        public AnalogClock(FastClock.FastClock fastClock)
        {
            InitializeComponent();

            _fastClock = fastClock;
            _fastClock.OnMinuteIsOver += FastClockOneMinuteIsOver;
            // Create an instance of RotateTransform objects
            MinHandTr = new RotateTransform();
            HourHandTr = new RotateTransform();
        }



        private void FastClockOneMinuteIsOver(object sender, DateTime e)
        {
            MinHandTr.Angle = (e.Minute * 6);
            HourHandTr.Angle = (e.Hour * 30) + (e.Minute * 0.5);
            Minutehand.RenderTransform = MinHandTr;
            Hourhand.RenderTransform = HourHandTr;
        }
    }
}
