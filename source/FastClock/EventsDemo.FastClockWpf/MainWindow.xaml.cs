using System;
using System.Windows;
using EventsDemo.FastClock;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private EventsDemo.FastClock.FastClock _fastClock;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            DatePickerDate.SelectedDate = DateTime.Today;
            TextBoxTime.Text = DateTime.Now.ToShortTimeString();
            _fastClock = EventsDemo.FastClock.FastClock.Instance;
            _fastClock.OnMinuteIsOver += FastClockOneMinuteIsOver;
        }

      
        private void ButtonSetTime_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SetFastClockStartDateAndTime()
        {
        }

        private void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
        {
            TextBlockTime.Text = fastClockTime.ToShortTimeString();
            TextBlockDate.Text = fastClockTime.ToShortDateString();
        }

        private void CheckBoxClockRuns_Click(object sender, RoutedEventArgs e)
        {
            _fastClock.IsRunning = CheckBoxClockRuns.IsChecked == true;
        }

        private void ButtonCreateView_Click(object sender, RoutedEventArgs e)
        {
            DigitalClock digitalClock = new DigitalClock();
            digitalClock.Owner = this;
            digitalClock.Show();
        }
    }
}
