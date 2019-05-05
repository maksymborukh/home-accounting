using Models.Collections;
using Models.Entities;
using Repository.Concrete.Operations;
using Service.Logic;
using System;
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

            List<Income> inc = new List<Income>(income.GetByFilter(month, year));
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

            List<Expense> exp = new List<Expense>(expense.GetAll());
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

            List<Expense> exp = new List<Expense>(expense.GetByFilter(month, year));
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
            List<Expense> exp = new List<Expense>(expense.GetAll());
            List<Income> inc = new List<Income>(income.GetAll());
            money.Calc(inc, exp);
        }

        public void FillSide(Money money, int month, int year)
        {
            List<Expense> exp = new List<Expense>(expense.GetByFilter(month, year));
            List<Income> inc = new List<Income>(income.GetByFilter(month, year));
            money.Calc(inc, exp);
        }
    }
}
