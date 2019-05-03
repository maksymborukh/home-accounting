using Service;
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
            Table.ItemsSource = windowLoaded.GetIncomes();            
        }

        private void Expense_Click(object sender, RoutedEventArgs e)
        {
            Table.ItemsSource = windowLoaded.GetExpenses();           
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
    }
}
