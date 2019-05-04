using Models.Entities;
using Repository.Concrete.Operations;
using System;

namespace Service.DataBaseHelper
{
    public class TransferToDB
    {
        private Expense Expense;
        private Income Income;

        public IncomeRepository income;
        public ExpenseRepository expense;

        public bool Save(string type, string descr, string price, string quantity, string amount, string percent, string date)
        {
            if (type.Equals("income"))
            {
                income = new IncomeRepository();
                Income = new Income()
                {
                    Description = descr,
                    Price = Convert.ToDouble(price),
                    Quantity = Convert.ToInt32(quantity),
                    Amount = Convert.ToDouble(amount),
                    Percent = Convert.ToDouble(percent),
                    Day = Convert.ToDateTime(date).Day,
                    Month = Convert.ToDateTime(date).Month,
                    Year = Convert.ToDateTime(date).Year
                };

                try
                {
                    income.Insert(Income);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                expense = new ExpenseRepository();
                Expense = new Expense()
                {

                    Description = descr,
                    Price = Convert.ToDouble(price),
                    Quantity = Convert.ToInt32(quantity),
                    Amount = Convert.ToDouble(amount),
                    Percent = Convert.ToDouble(percent),
                    Day = Convert.ToDateTime(date).Day,
                    Month = Convert.ToDateTime(date).Month,
                    Year = Convert.ToDateTime(date).Year
                };

                try
                {
                    expense.Insert(Expense);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Del(Income i, Expense e)
        {
            if (i != null)
            {
                income = new IncomeRepository();
                try
                {
                    income.Delete(i.Id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if(e != null)
            {
                expense = new ExpenseRepository();
                try
                {
                    expense.Delete(e.Id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
