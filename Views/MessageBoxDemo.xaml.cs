using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Study.Views
{
    /// <summary>
    /// MessageBoxDemo.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxDemo : Page
    {
        public MessageBoxDemo()
        {
            InitializeComponent();
        }
        // 简单的 MessageBox
        private void ShowSimpleMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a simple MessageBox.");
        }

        // 包含 Yes 和 No 按钮的 MessageBox
        private void ShowYesNoMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to continue?", "Question", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("You chose Yes.");
            }
            else
            {
                MessageBox.Show("You chose No.");
            }
        }

        // 包含 Yes, No 和 Cancel 按钮的 MessageBox
        private void ShowYesNoCancelMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Save Changes", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("You chose Yes.");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("You chose No.");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("You chose Cancel.");
                    break;
            }
        }

        // 包含图标的 MessageBox
        private void ShowMessageBoxWithIcon_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is an error message.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // 指定默认按钮的 MessageBox
        private void ShowMessageBoxWithDefaultButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Item deleted.");
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBox.Show("Delete cancelled.");
            }
        }

        // 打开文件对话框的按钮点击事件
        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            // 创建一个 OpenFileDialog 实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置过滤器（文件类型）
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // 显示对话框并检查用户是否选择了一个文件
            if (openFileDialog.ShowDialog() == true)
            {
                // 将选中文件的路径显示在 TextBox 中
                filePathTextBox.Text = openFileDialog.FileName;
                MessageBox.Show("打开成功!", "打开文件提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        // 保存文件对话框的按钮点击事件
        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            // 创建一个 SaveFileDialog 实例
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // 设置默认文件扩展名
            saveFileDialog.DefaultExt = ".txt";
            // 设置文件类型过滤器
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // 显示对话框并检查用户是否选择了保存文件
            if (saveFileDialog.ShowDialog() == true)
            {
                // 获取用户输入的文件路径
                string filePath = saveFileDialog.FileName;

                // 获取 TextBox 中的内容
                string content = contentTextBox.Text;

                // 将内容写入文件
                File.WriteAllText(filePath, content);
                // 显示保存成功的消息
                MessageBox.Show("保存成功!", "保存文件提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        // 打印对话框的按钮点击事件
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            // 创建一个 PrintDialog 实例
            PrintDialog printDialog = new PrintDialog();

            // 检查用户是否选择了打印机并点击“打印”
            if (printDialog.ShowDialog() == true)
            {
                // 获取 TextBox 中的内容
                string contentToPrint = printTextBox.Text;

                // 创建一个 FlowDocument 来存放打印内容
                FlowDocument doc = new FlowDocument(new Paragraph(new Run(contentToPrint)))
                {
                    // 设置打印文档的字体大小和其他格式
                    FontSize = 14,
                    FontFamily = new FontFamily("Arial"),
                    PagePadding = new Thickness(50)
                };

                // 创建一个 DocumentPaginatorSource 对象并打印文档
                IDocumentPaginatorSource idpSource = doc;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Printing Text");
            }
        }

    }
}
