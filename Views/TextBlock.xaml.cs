using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPF_Study.Views
{
    /// <summary>
    /// TextBlock.xaml 的交互逻辑
    /// </summary>
    public partial class TextBlock : Page
    {
        public TextBlock()
        {
            InitializeComponent();

            // 创建一个新的 FlowDocument
            FlowDocument flowDoc = new FlowDocument();

            // 创建第一个段落
            Paragraph para1 = new Paragraph();
            para1.Inlines.Add(new Run("This is a "));
            para1.Inlines.Add(new Run("RichTextBox") { FontStyle = FontStyles.Italic, FontSize = 40 });
            para1.Inlines.Add(new Run(" example with ") { Foreground = Brushes.Blue });
            para1.Inlines.Add(new Run("formatted text.") { FontSize = 16, FontWeight = FontWeights.Bold });
            flowDoc.Blocks.Add(para1);

            // 创建第二个段落
            Paragraph para2 = new Paragraph();
            para2.Inlines.Add(new Run("You can add more content here."));
            flowDoc.Blocks.Add(para2);

            // 设置 RichTextBox 的内容
            myRichTextBox.Document = flowDoc;
        }
    }
}