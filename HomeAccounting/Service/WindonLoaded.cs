﻿using Models.Collections;
using Models.Entities;
using Repository.Concrete.Operations;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Service
{
    public class WindowLoaded
    {
        public IncomeRepository income = new IncomeRepository();
        public ExpenseRepository expense = new ExpenseRepository();

        public ObservableCollection<Income> GetIncomes()
        {

            List<Income> inc = new List<Income>(income.GetAll());
            IncomeCollections incomeCollections = new IncomeCollections();
            incomeCollections.Add(inc);

            return incomeCollections.GetIncomes();
        }

        public ObservableCollection<Expense> GetExpenses()
        {

            List<Expense> exp = new List<Expense>(expense.GetAll());
            ExpenseCollections expenseCollections = new ExpenseCollections();
            expenseCollections.Add(exp);

            return expenseCollections.GetExpenses();
        }
    }
}