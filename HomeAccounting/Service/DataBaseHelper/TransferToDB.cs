using Models.Entities;
using Repository;
using System;

namespace Service.DataBaseHelper
{
    public class TransferToDB
    {
        private Expense Expense;
        private Income Income;
      
        public bool Save(string type, string descr, string price, string quantity, string amount, string date)
        {
            if (type.Equals("income"))
            {
                var dbType = Factory.GetFactory("incomedb");
                Income = new Income()
                {
                    Description = descr,
                    Price = Convert.ToDouble(price),
                    Quantity = Convert.ToInt32(quantity),
                    Amount = Convert.ToDouble(amount),
                    Day = Convert.ToDateTime(date).Day,
                    Month = Convert.ToDateTime(date).Month,
                    Year = Convert.ToDateTime(date).Year
                };

                try
                {
                    dbType.Insert(Income);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                var dbType = Factory.GetFactory("expensedb");
                Expense = new Expense()
                {

                    Description = descr,
                    Price = Convert.ToDouble(price),
                    Quantity = Convert.ToInt32(quantity),
                    Amount = Convert.ToDouble(amount),
                    Day = Convert.ToDateTime(date).Day,
                    Month = Convert.ToDateTime(date).Month,
                    Year = Convert.ToDateTime(date).Year
                };

                try
                {
                    dbType.Insert(Expense);
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
                var dbType = Factory.GetFactory("incomedb");
                try
                {
                    dbType.Delete(i.Id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if (e != null)
            {
                var dbType = Factory.GetFactory("expensedb");
                try
                {
                    dbType.Delete(e.Id);
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
