using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class ExpenseCollections
    {
        private ObservableCollection<Expense> expenses;

        public ExpenseCollections()
        {
            expenses = new ObservableCollection<Expense>();
        }

        //public void Add(Expense expense)
        //{
        //    expenses.Add(expense);
        //}

        public ObservableCollection<Expense> GetExpenses()
        {
            return expenses;
        }
    }
}
