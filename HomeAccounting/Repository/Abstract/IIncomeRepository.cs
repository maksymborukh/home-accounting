using Models.Entities;
using System.Collections.ObjectModel;

namespace Repository.Abstract
{
    interface IIncomeRepository
    {
        void Insert(Income income);
        void Delete(long Id);
        void Update(Income income);
        ObservableCollection<Income> GetAll();
        Income GetByID(long id);
    }
}
