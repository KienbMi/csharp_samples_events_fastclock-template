using System;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock
    {
        private EventsDemo.FastClock.FastClock _fastClock;
        
        public DigitalClock(FastClock.FastClock fastClock)
        {
            InitializeComponent();
            _fastClock = fastClock;
            _fastClock.OnMinuteIsOver += FastClockOneMinuteIsOver;
        }

        private void FastClockOneMinuteIsOver(object sender, DateTime e)
        {
            TextBlockClock.Text = e.ToShortTimeString();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
        }

    }
}
