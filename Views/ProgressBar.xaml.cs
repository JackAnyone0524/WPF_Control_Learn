using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPF_Study.Views
{
    /// <summary>
    /// ProgressBar.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressBar : Page
    {
        public ProgressBar()
        {
            InitializeComponent();

            // 初始化时间显示
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        #region ProgressBar

        // 增加进度
        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (myProgressBar.Value < myProgressBar.Maximum)
            {
                myProgressBar.Value += 10;
                progressText.Text = $"Progress: {myProgressBar.Value}%";
            }
        }

        // 减少进度
        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (myProgressBar.Value > myProgressBar.Minimum)
            {
                myProgressBar.Value -= 10;
                progressText.Text = $"Progress: {myProgressBar.Value}%";
            }
        }

        #endregion ProgressBar

        #region
        // 更新时间显示
        private void Timer_Tick(object sender, EventArgs e)
        {
            timeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        // 增加进度条的值
        private void IncreaseProgressButton_Click(object sender, RoutedEventArgs e)
        {
            if (statusProgressBar.Value < statusProgressBar.Maximum)
            {
                statusProgressBar.Value += 10;
            }
        }
        #endregion
    }
}