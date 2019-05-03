using Models.Entities;
using System.Collections.Generic;
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

        public void Add(List<Expense> expenses)
        {
            foreach (var exp in expenses)
            {
                this.expenses.Add(exp);
            }
        }

        public ObservableCollection<Expense> GetExpenses()
        {
            return expenses;
        }
    }
}
