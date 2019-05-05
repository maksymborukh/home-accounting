using Models.Entities;
using Service;
using Service.DataBaseHelper;
using Service.Logic;
using System;
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
        private Money Money;
        private bool Inc = true;
        private bool Exp = false;
        public MainWindow()
        {      
            InitializeComponent();
            windowLoaded = new WindowLoaded();
            Money = new Money();
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
            if (Table.SelectedItem != null && MessageBox.Show("Delete?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (Inc)
                {
                    Income income = (Income)Table.SelectedItems[0];
                    TransferToDB transferToDB = new TransferToDB();
                    if (transferToDB.Del(income, null))
                    {
                        MessageBox.Show("Deleted.");
                    }
                    else
                    {
                        MessageBox.Show("Error. Try again later.");
                    }
                }   
                else if (Exp)
                {
                    Expense expense = (Expense)Table.SelectedItems[0];
                    TransferToDB transferToDB = new TransferToDB();
                    if (transferToDB.Del(null, expense))
                    {
                        MessageBox.Show("Deleted.");
                    }
                    else
                    {
                        MessageBox.Show("Error. Try again later.");
                    }
                }
            }
            else
            {
                Table.SelectedItem = null;
            }
        }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            if (CalendarText.Text == "ALL")
            {
                Table.ItemsSource = windowLoaded.GetIncomes();
                windowLoaded.FillSide(Money);
            }
            else
            {
                Table.ItemsSource = windowLoaded.GetIncomes(Calendar.DisplayDate.Month, Calendar.DisplayDate.Year);
                windowLoaded.FillSide(Money, Calendar.DisplayDate.Month, Calendar.DisplayDate.Year);
            }
            IncomeSide.Text = Money.income;
            ExpenseSide.Text = Money.expense;
            CurrencySide.Text = Money.currency;
            BalanceSide.Text = Money.balance;
            Inc = true;
            Exp = false;
        }

        private void Expense_Click(object sender, RoutedEventArgs e)
        {
            if (CalendarText.Text == "ALL")
            {
                Table.ItemsSource = windowLoaded.GetExpenses();
                windowLoaded.FillSide(Money);
            }
            else
            {
                Table.ItemsSource = windowLoaded.GetExpenses(Calendar.DisplayDate.Month, Calendar.DisplayDate.Year);
                windowLoaded.FillSide(Money, Calendar.DisplayDate.Month, Calendar.DisplayDate.Year);
            }
            IncomeSide.Text = Money.income;
            ExpenseSide.Text = Money.expense;
            CurrencySide.Text = Money.currency;
            BalanceSide.Text = Money.balance;
            Inc = false;
            Exp = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CalendarText.Text == "ALL")
            {
                windowLoaded.FillSide(Money);
                Table.ItemsSource = windowLoaded.GetIncomes();
            }
            else
            {
                windowLoaded.FillSide(Money, Calendar.DisplayDate.Month, Calendar.DisplayDate.Year);
            }
            IncomeSide.Text = Money.income;
            ExpenseSide.Text = Money.expense;
            CurrencySide.Text = Money.currency;
            BalanceSide.Text = Money.balance;
        }

        private void OpenAddWindow_Click(object sender, RoutedEventArgs e)
        {
            AddWindow.Visibility = Visibility.Visible;
            DescriptionInput.IsEnabled = false;
            AmountInput.IsEnabled = false;
            DateInput.IsEnabled = false;
            PriceInput.IsEnabled = false;
            QuantityInput.IsEnabled = false;
        }

        private void CloseAddWindow_Click(object sender, RoutedEventArgs e)
        {
            AddWindow.Visibility = Visibility.Collapsed;
            IncomeRadioButton.IsChecked = false;
            ExpenseRadioButton.IsChecked = false;
        }

        private void SaveInput_Click(object sender, RoutedEventArgs e)
        {
            if (IncomeRadioButton.IsChecked == true)
            {
                TransferToDB transferToDB = new TransferToDB();
                if (!transferToDB.Save("income", DescriptionInput.Text, "0", "0",
                    AmountInput.Text, DateInput.Text))
                {
                    MessageBox.Show("Error. Try again later.");
                }
                else
                {
                    MessageBox.Show("Added.");
                    AddWindow.Visibility = Visibility.Collapsed;
                }
            }
            else if(ExpenseRadioButton.IsChecked == true)
            {
                Amount Amount = new Amount();
                string amount = Amount.CalcAmount(Convert.ToDouble(PriceInput.Text), Convert.ToInt32(QuantityInput.Text)).ToString();
                TransferToDB transferToDB = new TransferToDB();
                if (!transferToDB.Save("expense", DescriptionInput.Text, PriceInput.Text, QuantityInput.Text,
                    amount, DateInput.Text))
                {
                    MessageBox.Show("Error. Try again later");
                }
                else
                {
                    MessageBox.Show("Added.");
                    AddWindow.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                MessageBox.Show("Choose one!");
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

        private void IncomeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            DescriptionInput.IsEnabled = true;
            AmountInput.IsEnabled = true;
            DateInput.IsEnabled = true;
            PriceInput.IsEnabled = false;
            QuantityInput.IsEnabled = false;
        }

        private void ExpenseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            DescriptionInput.IsEnabled = true;
            AmountInput.IsEnabled = false;
            DateInput.IsEnabled = true;
            PriceInput.IsEnabled = true;
            QuantityInput.IsEnabled = true;
        }
    }
}
