using Models.Collections;
using Models.Entities;
using Repository;
using Service.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Service
{
    public class WindowLoaded
    {
        public ObservableCollection<Income> GetIncomes()
        {
            var dbType = Factory.GetFactory("income" + dbOrFile.Type);
            List<Income> inc = new List<Income>();
            List<object> list = new List<object>(dbType.GetAll());
            foreach (var o in list)
            {
                inc.Add((Income)o);
            }
            List<Income> incomes = new List<Income>();
            IncomeCollections incomeCollections = new IncomeCollections();
            Percent percent = new Percent();

            foreach (var income in inc)
            {
                income.Percent = Math.Round(percent.CalcPercent(income.Amount, inc), 3);
                incomes.Add(income);
            }

            incomeCollections.Add(incomes);

            return incomeCollections.GetIncomes();
        }

        public ObservableCollection<Income> GetIncomes(int month, int year)
        {
            var dbType = Factory.GetFactory("income" + dbOrFile.Type);
            List<Income> inc = new List<Income>();
            List<object> list = new List<object>(dbType.GetByFilter(month, year));
            foreach (var o in list)
            {
                inc.Add((Income)o);
            }
            List<Income> incomes = new List<Income>();
            IncomeCollections incomeCollections = new IncomeCollections();
            Percent percent = new Percent();

            foreach (var income in inc)
            {
                income.Percent = Math.Round(percent.CalcPercent(income.Amount, inc), 3);
                incomes.Add(income);
            }

            incomeCollections.Add(incomes);

            return incomeCollections.GetIncomes();
        }

        public ObservableCollection<Expense> GetExpenses()
        {
            var dbType = Factory.GetFactory("expense" + dbOrFile.Type);
            List<Expense> exp = new List<Expense>();
            List<object> list = new List<object>(dbType.GetAll());
            foreach (var o in list)
            {
                exp.Add((Expense)o);
            }
            List<Expense> expenses = new List<Expense>();
            ExpenseCollections expenseCollections = new ExpenseCollections();
            Percent percent = new Percent();

            foreach (var expense in exp)
            {
                expense.Percent = Math.Round(percent.CalcPercent(expense.Amount, exp), 3);
                expenses.Add(expense);
            }

            expenseCollections.Add(expenses);

            return expenseCollections.GetExpenses();
        }

        public ObservableCollection<Expense> GetExpenses(int month, int year)
        {
            var dbType = Factory.GetFactory("expense" + dbOrFile.Type);
            List<Expense> exp = new List<Expense>();
            List<object> list = new List<object>(dbType.GetByFilter(month, year));
            foreach (var o in list)
            {
                exp.Add((Expense)o);
            }
            List<Expense> expenses = new List<Expense>();
            ExpenseCollections expenseCollections = new ExpenseCollections();
            Percent percent = new Percent();

            foreach (var expense in exp)
            {
                expense.Percent = Math.Round(percent.CalcPercent(expense.Amount, exp), 3);
                expenses.Add(expense);
            }

            expenseCollections.Add(expenses);

            return expenseCollections.GetExpenses();
        }

        public void FillSide(Money money)
        {
            var dbType = Factory.GetFactory("expense" + dbOrFile.Type);
            List<Expense> exp = new List<Expense>();
            List<object> list = new List<object>(dbType.GetAll());
            foreach (var o in list)
            {
                exp.Add((Expense)o);
            }
            var dbType2 = Factory.GetFactory("income" + dbOrFile.Type);
            List<Income> inc = new List<Income>();
            List<object> list2 = new List<object>(dbType2.GetAll());
            foreach (var o in list2)
            {
                inc.Add((Income)o);
            }
            money.Calc(inc, exp);
        }

        public void FillSide(Money money, int month, int year)
        {
            var dbType = Factory.GetFactory("expense" + dbOrFile.Type);
            List<Expense> exp = new List<Expense>();
            List<object> list = new List<object>(dbType.GetByFilter(month, year));
            foreach (var o in list)
            {
                exp.Add((Expense)o);
            }
            var dbType2 = Factory.GetFactory("income" + dbOrFile.Type);
            List<Income> inc = new List<Income>();
            List<object> list2 = new List<object>(dbType2.GetByFilter(month, year));
            foreach (var o in list2)
            {
                inc.Add((Income)o);
            }
            money.Calc(inc, exp);
        }
    }
}
