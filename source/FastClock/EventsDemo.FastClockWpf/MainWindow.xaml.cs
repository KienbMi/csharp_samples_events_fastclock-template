using System;
using System.Windows;

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
            SetFastClockStartDateAndTime();
        }

        private void SetFastClockStartDateAndTime()
        {
            DateTime dateTime = DatePickerDate.SelectedDate.Value;
            DateTime time;

            if (DateTime.TryParse(TextBoxTime.Text, out time))
            {
                dateTime = dateTime.AddMinutes(time.TimeOfDay.TotalMinutes);
                _fastClock.Time = dateTime;
            }
        }

        private void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
        {
            TextBlockTime.Text = fastClockTime.ToShortTimeString();
            TextBlockDate.Text = fastClockTime.ToShortDateString();
        }

        private void CheckBoxClockRuns_Click(object sender, RoutedEventArgs e)
        {
            _fastClock.Factor = int.Parse(TextBoxFactor.Text);
            _fastClock.IsRunning = CheckBoxClockRuns.IsChecked == true;
        }

        private void ButtonCreateView_Click(object sender, RoutedEventArgs e)
        {
            DigitalClock digitalClock = new DigitalClock(_fastClock);
            digitalClock.Owner = this;
            digitalClock.Show();
        }

        private void ButtonCreateViewAnalog_Click(object sender, RoutedEventArgs e)
        {
            AnalogClock analogClock = new AnalogClock(_fastClock);
            analogClock.Owner = this;
            analogClock.Show();
        }
    }
}
