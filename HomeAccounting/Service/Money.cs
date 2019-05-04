using Models.Entities;
using System.Collections.Generic;

namespace Service
{
    public class Money
    {
        public string income { get; set; }
        public string expense { get; set; }
        public string currency { get; set; }
        public string balance { get; set; }

        public void Calc(List<Income> incomes, List<Expense> expenses)
        {
            double inc = 0;
            double exp = 0;
            foreach (var i in incomes)
            {
                inc = inc + i.Price * i.Quantity;
            }
            income = inc.ToString();

            foreach (var e in expenses)
            {
                exp = exp + e.Price * e.Quantity;
            }
            expense = exp.ToString();
            currency = "ukrainian hryvnia";
            balance = (inc - exp).ToString();
        }
    }//todo mast calculate by amount
}
