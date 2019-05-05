using Models.Entities;
using System.Collections.Generic;

namespace Service.Logic
{
    public class Percent
    {
        public double CalcPercent(double amount, List<Income> incomes)
        {
            double inc = 0;
            foreach (var i in incomes)
            {
                inc = inc + i.Amount;
            }

            double percent = 100 * amount / inc;

            return percent;
        }

        public double CalcPercent(double amount, List<Expense> expenses)
        {
            double inc = 0;
            foreach (var i in expenses)
            {
                inc = inc + i.Amount;
            }

            double percent = 100 * amount / inc;

            return percent;
        }
    }
}
