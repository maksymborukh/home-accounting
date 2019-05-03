using Models.Entities;
using Repository.Concrete.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    AddDate = date
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
                    AddDate = date
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
    }
}
