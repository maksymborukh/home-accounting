using Models.Entities;
using System.Collections.ObjectModel;

namespace Repository.Abstract
{
    interface IExpenseRepository
    {
        void Insert(Expense expense);
        void Delete(long Id);
        void Update(Expense expense);
        ObservableCollection<Expense> GetAll();
        Expense GetByID(long id);
    }
}
