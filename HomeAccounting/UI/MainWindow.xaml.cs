using System.Windows;
using System.Windows.Input;


namespace UI
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

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Support_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("In developing");
        }

        private void Left_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Right_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Calendar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Income_Click(object sender, RoutedEventArgs e)
        {
            Table.ItemsSource = "{Binding Source={StaticResource IncomeProvider}}";
        }

        private void Expense_Click(object sender, RoutedEventArgs e)
        {
            Table.ItemsSource = "{Binding Source={StaticResource ExpenseProvider}}";
        }
    }
}
