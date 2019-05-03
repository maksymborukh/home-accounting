using Models.Entities;
using System.Collections.Generic;
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

        public void Add(List<Income> incomes)
        {
            foreach (var inc in incomes)
            {
                this.incomes.Add(inc);
            }
        }

        public ObservableCollection<Income> GetIncomes()
        {
            
            return incomes;
        }
    }
}
