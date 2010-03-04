using System;
using System.Windows.Threading;
using System.Windows.Input;

namespace WristSlapper
{
    public class Controller
    {
        private MainWindow mainWindow;
        private TimeElapsedTimer timer;
        private int mouseMovedCount;
        
        public Controller()
        {
            mouseMovedCount = 0;
            timer = new TimeElapsedTimer();
        }
        
        public void Launch()
        {
            mainWindow = new MainWindow(this);
            
            mainWindow.ElapsedTime = new TimeSpan();
            mainWindow.MouseMovementCount = mouseMovedCount;
            mainWindow.MouseMove += Mouse_Moved;
            mainWindow.MouseDoubleClick +=WhenStartingTimer;
            
            mainWindow.Show();
            
            timer.Tick += Timer_Tick;
        }     
        
        private void WhenStartingTimer(object sender, EventArgs e)
        {
            timer.Start();
            System.Windows.Forms.Cursor.Hide();
        }
        
        private void Mouse_Moved(object sender, EventArgs e)
        {
            if (timer.IsCounting)
            {
                mainWindow.MouseMovementCount = ++mouseMovedCount;
                timer.Stop();
                System.Windows.Forms.Cursor.Show();
            }
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.mainWindow.ElapsedTime = timer.ElapsedTime;
        }
    }
}
