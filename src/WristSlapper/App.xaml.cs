using System;
using System.Windows;

namespace WristSlapper
{
    public partial class App : Application
    {
        
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Controller controller = new Controller();
            controller.Launch();
        }        
    }
}