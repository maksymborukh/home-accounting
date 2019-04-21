using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Expense
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public double Percent { get; set; }
        public string Date { get; set; }
    }
}
