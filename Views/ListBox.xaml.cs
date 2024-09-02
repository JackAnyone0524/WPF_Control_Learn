using System.Windows.Controls;

namespace WPF_Study.Views
{
    /// <summary>
    /// ListBox.xaml 的交互逻辑
    /// </summary>
    public partial class ListBox : Page
    {
        public ListBox()
        {
            InitializeComponent();
            DataGridDemo();
            ListViewDemo();
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 获取选中的 ListBoxItem
            ListBoxItem selectedItem = myListBox.SelectedItem as ListBoxItem;
            if (selectedItem != null && selectedItemTextBlock != null)
            {
                // 更新 TextBlock 显示选中的内容
                selectedItemTextBlock.Text = $"Selected: {selectedItem.Content.ToString()}";
            }
        }

        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 获取选中的 ComboBoxItem
            ComboBoxItem selectedItem = myComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem != null && selectedOptionTextBlock != null)
            {
                // 将选中项的内容显示在 TextBlock 中
                selectedOptionTextBlock.Text = $"Selected: {selectedItem.Content.ToString()}";
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Person> People { get; set; }

        public void DataGridDemo()
        {
            InitializeComponent();
            People = new System.Collections.ObjectModel.ObservableCollection<Person>
            {
                new Person { Name = "张三", Age = 30 },
                new Person { Name = "李四", Age = 25 },
                new Person { Name = "王二麻子", Age = 42 }
            };
            myDataGrid.ItemsSource = People;
        }

        public void ListViewDemo()
        {
            InitializeComponent();
            People = new System.Collections.ObjectModel.ObservableCollection<Person>
            {
                new Person { Name = "张三", Age = 30 },
                new Person { Name = "李四", Age = 25 },
                new Person { Name = "王二麻子", Age = 42 }
            };
            myListView.ItemsSource = People;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}