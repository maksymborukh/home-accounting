using Models.Entities;
using System.Collections.ObjectModel;

namespace Models.Collections
{
    public class IncomeCollections
    {
        private ObservableCollection<Income> incomes;

        public IncomeCollections()
        {
            incomes = new ObservableCollection<Income>();
        }

        //public void Add(Income income)
        //{
        //    incomes.Add(income);
        //}

        public ObservableCollection<Income> GetIncomes()
        {
            return incomes;
        }
    }
}
