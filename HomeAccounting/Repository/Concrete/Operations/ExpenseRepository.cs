using Models.Entities;
using Repository.Abstract;
using Repository.Core;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace Repository.Concrete.Operations
{
    public class ExpenseRepository : IExpenseRepository
    {
        DBManager dbManager = new DBManager("account");
        IDbConnection connection = null;

        public void Insert(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Expense> GetAll()
        {
            throw new NotImplementedException();
        }

        public Expense GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
