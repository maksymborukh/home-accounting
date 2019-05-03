using Models.Entities;
using System.Collections.Generic;

namespace Repository.Abstract
{
    interface IExpenseRepository
    {
        void Insert(Expense expense);
        void Delete(long Id);
        void Update(Expense expense);
        List<Expense> GetAll();
        Expense GetByID(long id);
    }
}
