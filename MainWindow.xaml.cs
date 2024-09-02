using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace WPF_Study
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int tabCounter = 0;

        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            ExpandAllTreeViewItems(MyTreeView.Items);
        }

        private void ExpandAllTreeViewItems(ItemCollection items)
        {
            return;
            foreach (object item in items)
            {
                TreeViewItem treeViewItem = item as TreeViewItem;
                if (treeViewItem != null)
                {
                    treeViewItem.IsExpanded = true;
                    ExpandAllTreeViewItems(treeViewItem.Items);
                }
            }
        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // 获取点击的按钮
            var button = sender as TreeViewItem;
            if (button != null)
            {
                string ContentParameter = button.Header.ToString();
                string strHeader = button.Header.ToString().Replace(button.Tag.ToString(), string.Empty).Trim();

                // 检查是否已经存在相同内容的选项卡
                foreach (TabItem tab in MyTabControl.Items)
                {
                    if (tab.Header.ToString() == $"{ContentParameter}")
                    {
                        // 如果找到匹配的选项卡，则将其设置为选中状态
                        MyTabControl.SelectedItem = tab;
                        return;
                    }
                }

                // 如果没有找到匹配的选项卡，则创建一个新的 TabItem
                var newTab = new TabItem
                {
                    Header = $"{ContentParameter}", // 设置选项卡的标题
                };

                // 创建一个 Frame，并将 Page 作为 Frame 的内容
                var frame = new Frame();
                frame.NavigationUIVisibility = NavigationUIVisibility.Hidden; // 隐藏导航栏

                frame.Content = TabToPage(strHeader); // 将 MyPage 替换为你实际的 Page
                newTab.Content = frame;
                // 将新创建的 TabItem 添加到 TabControl 中
                MyTabControl.Items.Add(newTab);

                // 将新添加的 TabItem 设置为选中状态
                MyTabControl.SelectedItem = newTab;
            }
        }

        public Page TabToPage(string strHeader)
        {
            string className = "WPF_Study.Views." + strHeader;
            // 获取类型信息
            Type type = Type.GetType(className);

            if (type != null)
            {
                // 实例化对象
                object instance = Activator.CreateInstance(type);

                return instance as Page;
            }
            else
            {
                return default;
            }
        }
    }
}