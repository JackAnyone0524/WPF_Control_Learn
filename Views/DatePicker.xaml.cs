using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace WPF_Study.Views
{
    /// <summary>
    /// DatePicker.xaml 的交互逻辑
    /// </summary>
    public partial class DatePicker : Page, INotifyPropertyChanged
    {
        public DatePicker()
        {
            InitializeComponent();
            DataContext = this;
        }

        // 处理日期选择变更事件
        private void myDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // 获取选择的日期并更新 TextBlock
            if (myDatePicker.SelectedDate.HasValue)
            {
                selectedDateTextBlock.Text = $"Selected Date: {myDatePicker.SelectedDate.Value.ToShortDateString()}";
            }
        }

        #region
        private DateTime? selectedDate;

        public DateTime? SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnPropertyChanged("SelectedDate");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }

        #endregion

        #region sliderValue

        private double sliderValue;

        public double SliderValue
        {
            get { return sliderValue; }
            set
            {
                sliderValue = value;
                OnPropertyChanged("SliderValue");
            }
        }

        #endregion
    }
}