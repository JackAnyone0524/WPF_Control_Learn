using System.Windows;

namespace WPF_Study
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // 可以在这里执行其他初始化代码

            //MessageBox.Show("初始化窗体!");
        }
    }
}