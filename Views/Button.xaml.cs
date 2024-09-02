using System.Windows;
using System.Windows.Controls;

namespace WPF_Study.Views
{
    /// <summary>
    /// Button.xaml 的交互逻辑
    /// </summary>
    public partial class Button : Page
    {
        public Button()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            // 弹出一个消息框
            MessageBox.Show("Button clicked!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private double currentValue = 0;

        private void myRepeatButton_Click(object sender, RoutedEventArgs e)
        {
            // 增加当前值
            currentValue += 0.1;
            valueTextBlock.Text = currentValue.ToString();
        }

        // ToggleButton 被选中时的处理方法
        private void myToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            statusTextBlock.Text = "Status: On";
            myToggleButton.Content = "Turn Off";
            statusTextBlock.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
        }

        // ToggleButton 被取消选中时的处理方法
        private void myToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            statusTextBlock.Text = "Status: Off";
            myToggleButton.Content = "Turn On";
            statusTextBlock.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
        }

        // 用于防止递归调用的标志位
        private bool isHandlingCheck = false;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (isHandlingCheck) return;
            try
            {
                isHandlingCheck = true;

                RadioButton selectedRadioButton = sender as RadioButton;
                if (selectedRadioButton != null && selectedOptionTextBlock != null)
                {
                    selectedOptionTextBlock.Text = $"Selected: {selectedRadioButton.Content}";
                }
            }
            finally
            {
                isHandlingCheck = false;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateSelectedOptions();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateSelectedOptions();
        }

        private void UpdateSelectedOptions()
        {
            if (selectedOptionsTextBlock == null)
            {
                return;
            }

            // 获取所有选中的 CheckBox
            var selectedOptions = string.Empty;

            if (checkBox1.IsChecked == true)
            {
                selectedOptions += checkBox1.Content.ToString() + " ";
            }
            if (checkBox2.IsChecked == true)
            {
                selectedOptions += checkBox2.Content.ToString() + " ";
            }
            if (checkBox3.IsChecked == true)
            {
                selectedOptions += checkBox3.Content.ToString() + " ";
            }
            // 更新 TextBlock 显示
            selectedOptionsTextBlock.Text = $"Selected: {(string.IsNullOrWhiteSpace(selectedOptions) ? "None" : selectedOptions.Trim())}";
        }
    }
}