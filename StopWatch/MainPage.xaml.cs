using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace StopWatch
{
    public sealed partial class MainPage : Page
    {
        Stopwatch stopwatch = new Stopwatch();

        public MainPage()
        {
            InitializeComponent();
            dispatcherTimer = new DispatcherTimer();
        }

        DispatcherTimer dispatcherTimer;
        DateTimeOffset currentTime;
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            if (MyButton.IsChecked.Value)
            {
                currentTime = DateTimeOffset.Now;
                MyButton.Content = "Stop Timer";
                dispatcherTimer.Start();
            }
            else
            {
                MyButton.Content = "Start Timer";
                dispatcherTimer.Stop();
            }
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            TimeSpan difference = DateTimeOffset.Now - currentTime;
            DisplayText.Text = string.Format("{0:00}:{1:00}:{2:00}:{3:000}",difference.Hours,difference.Minutes,difference.Seconds,difference.Milliseconds);
        }
    }
}
