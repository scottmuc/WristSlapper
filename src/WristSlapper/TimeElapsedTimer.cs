
using System;
using System.Windows.Threading;

namespace WristSlapper
{
    public class TimeElapsedTimer
    {
        private DispatcherTimer timer;
        private DateTime timerStartDate;
        
        public EventHandler Tick = (s, e) => {};
        
        public TimeElapsedTimer()
        {
            this.timer = new DispatcherTimer();
            this.timer.Tick += (s, e) => { Tick(this, EventArgs.Empty); };
            this.timer.Interval = TimeSpan.FromMilliseconds(1000);              
        }
        
        public void Start()
        {
            this.timerStartDate = DateTime.Now;
            this.timer.Start();
        }
        
        public void Stop()
        {
            this.timer.Stop();
        }
        
        public TimeSpan ElapsedTime
        {
            get { return DateTime.Now.Subtract(timerStartDate); }
        }
        
        public bool IsCounting
        {
            get { return timer.IsEnabled; }
        }
    }
}
