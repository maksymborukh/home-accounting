using System;

namespace Models.Entities
{
    public class Income
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public double Percent { get; set; }
        public DateTime Date { get; set; }
    }
}
