using System;
using System.Windows.Threading;

namespace EventsDemo.FastClock
{
    public class FastClock
    {
        private static FastClock _instance = null;
        private readonly DispatcherTimer _timer;
        private bool _isRunning;
        private DateTime _currentTime;
        private int _factor = 60;

        public int Factor
        {
            get => _factor;

            set
            {
                if (value <= 0)
                {
                    _factor = 1;
                }
                else if (_factor > 60000)
                {
                    _factor = 60000;
                }
                else
                {
                    _factor = value;
                }
            }
        }

        public static FastClock Instance 
        {
            get
            {
                if (_instance == null)
                    _instance = new FastClock();

                return _instance;
            }
        }

        public bool IsRunning 
        { 
            get => _isRunning;     
            
            set
            {
                if (!_isRunning && value)
                {
                    _timer.Interval = TimeSpan.FromMilliseconds(60000/_factor);
                    _timer.Start();
                }
                else if (_isRunning && value == false)
                {
                    _timer.Stop();
                }
                _isRunning = value;
            }    
        }

        public DateTime Time
        {
            get
            {
                return _currentTime;
            }
            
            set 
            {
                _currentTime = value;
                OnOneMinuteIsOver(_currentTime);
            } 
        }

        public event EventHandler<DateTime> OnMinuteIsOver;

        private FastClock()
        {
            _currentTime = DateTime.Now;
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _currentTime = _currentTime.AddMinutes(1);
            OnOneMinuteIsOver(_currentTime);
        }

        protected virtual void OnOneMinuteIsOver(DateTime time)
        {
            OnMinuteIsOver?.Invoke(this, time);
        }
    }
}
