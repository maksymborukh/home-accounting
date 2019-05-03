using Service;
using Service.DataBaseHelper;
using System.Windows;
using System.Windows.Input;


namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowLoaded windowLoaded;
        public MainWindow()
        {      
            InitializeComponent();
            windowLoaded = new WindowLoaded();
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Support_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("In developing");
        }

        private void Calendar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Calendar.Visibility = Visibility.Visible;
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            if (CalendarText.Text == "ALL")
            {
                Table.ItemsSource = windowLoaded.GetIncomes();
            }
            else
            {
                Table.ItemsSource = windowLoaded.GetIncomes(Calendar.DisplayDate.Month, Calendar.DisplayDate.Year);
            }
        }

        private void Expense_Click(object sender, RoutedEventArgs e)
        {
            if (CalendarText.Text == "ALL")
            {
                Table.ItemsSource = windowLoaded.GetExpenses();
            }
            else
            {
                Table.ItemsSource = windowLoaded.GetExpenses(Calendar.DisplayDate.Month, Calendar.DisplayDate.Year);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //WindowLoaded windowLoaded = new WindowLoaded();
            //windowLoaded.GetIncomes();
        }

        private void OpenAddWindow_Click(object sender, RoutedEventArgs e)
        {
            AddWindow.Visibility = Visibility.Visible;
        }

        private void CloseAddWindow_Click(object sender, RoutedEventArgs e)
        {
            AddWindow.Visibility = Visibility.Collapsed;
        }

        private void SaveInput_Click(object sender, RoutedEventArgs e)
        {
            if (IncomeRadioButton.IsChecked == true)
            {
                TransferToDB transferToDB = new TransferToDB();
                if (!transferToDB.Save("income", DescriptionInput.Text, PriceInput.Text, QuantityInput.Text,
                    AmountInput.Text, PercentInput.Text, DateInput.Text))
                {
                    MessageBox.Show("Error. Try again later.");
                }
                else
                {
                    MessageBox.Show("Added.");
                    AddWindow.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                TransferToDB transferToDB = new TransferToDB();
                if (!transferToDB.Save("expense", DescriptionInput.Text, PriceInput.Text, QuantityInput.Text,
                    AmountInput.Text, PercentInput.Text, DateInput.Text))
                {
                    MessageBox.Show("Added.");
                }
                else
                {
                    AddWindow.Visibility = Visibility.Collapsed;
                }
            }           
        }

        private void Calendar_DisplayModeChanged(object sender, System.Windows.Controls.CalendarModeChangedEventArgs e)
        {
            if (Calendar.DisplayMode == System.Windows.Controls.CalendarMode.Month)
            {
                CalendarText.Text = GetMonthName(Calendar.DisplayDate.Month) + " " + Calendar.DisplayDate.Year;
                Calendar.Visibility = Visibility.Collapsed;
                Calendar.DisplayMode = System.Windows.Controls.CalendarMode.Year;
            }
        }

        private string GetMonthName(int n)
        {
            switch (n)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "Error";
            }
        }

        private void CalendarAll_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CalendarText.Text = "ALL";
        }
    }
}
