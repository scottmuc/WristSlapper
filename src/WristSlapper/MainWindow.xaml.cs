﻿using System;
using System.Windows;
using System.Windows.Media;

namespace WristSlapper
{

    public partial class MainWindow : Window
    {
        private readonly Controller controller;
        
        public MainWindow(Controller controller)     
        {
            this.controller = controller;
            InitializeComponent();
        }
        
        public TimeSpan ElapsedTime
        {
            set
            {
                DateTime timeElapsed = new DateTime(value.Ticks);
                txtTimeElapsed.Text = string.Format("{0:H:mm:ss}", timeElapsed);
            }
        }
        
        public int MouseMovementCount
        {
            set
            {
                txtMouseMovementCount.Text = string.Format("You've moved the mouse {0} times in this session", value);
            }
        }
        
        public void TimerStarted()
        {
            txtTimeElapsed.Foreground = new SolidColorBrush(Colors.Green);
        }
        
        public void TimerStopped()
        {
            txtTimeElapsed.Foreground = new SolidColorBrush(Colors.Red);
        }
    }
}