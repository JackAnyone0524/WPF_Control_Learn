using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Study.Views
{
    /// <summary>
    /// Image.xaml 的交互逻辑
    /// </summary>
    public partial class Image : Page, INotifyPropertyChanged
    {
        public Image()
        {
            InitializeComponent();
            DataContext = this;
            ImagePath = "../Images/sample.png"; // 请确保项目中有此图片
        }

        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
        }

        private void myMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            // 在视频结束时将其重新播放
            myMediaElement.Position = new System.TimeSpan(0);
            myMediaElement.Play();
        }
    }
}