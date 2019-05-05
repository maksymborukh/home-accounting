using Models.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.Concrete.Operations
{
    public class IncomeFile : IRepository
    {
        private long AutoincrementId = 0;
        private string Directory =  AppDomain.CurrentDomain.BaseDirectory;

        public void Delete(long Id)
        {
            string[] parsedLine;

            var incomes = new List<Income>();
            List<object> list = new List<object>();
            var lines = File.ReadLines(Directory + "income.txt");
            foreach (var line in lines)
            {
                parsedLine = line.Split(' ');

                var income = new Income();
                income.Id = Convert.ToInt64(parsedLine[0]);
                income.Description = parsedLine[1];
                income.Price = Convert.ToDouble(parsedLine[2]);
                income.Quantity = Convert.ToInt32(parsedLine[3]);
                income.Amount = Convert.ToDouble(parsedLine[4]);
                income.Day = Convert.ToInt32(parsedLine[5]);
                income.Month = Convert.ToInt32(parsedLine[6]);
                income.Year = Convert.ToInt32(parsedLine[7]);
                incomes.Add(income);
            }

            File.WriteAllText(Directory + "income.txt", string.Empty);

            foreach (var income in incomes)
            {
                if (income.Id != Id)
                {
                    File.AppendAllText(Directory + "income.txt", MakeString(income));
                }
            }
        }

        public List<object> GetAll()
        {
            string[] parsedLine;

            var incomes = new List<Income>();
            List<object> list = new List<object>();
            var lines = File.ReadLines(Directory + "income.txt");
            foreach (var line in lines)
            {
                parsedLine = line.Split(' ');

                var income = new Income();
                income.Id = Convert.ToInt64(parsedLine[0]);
                income.Description = parsedLine[1];
                income.Price = Convert.ToDouble(parsedLine[2]);
                income.Quantity = Convert.ToInt32(parsedLine[3]);
                income.Amount = Convert.ToDouble(parsedLine[4]);
                income.Day = Convert.ToInt32(parsedLine[5]);
                income.Month = Convert.ToInt32(parsedLine[6]);
                income.Year = Convert.ToInt32(parsedLine[7]);
                incomes.Add(income);
            }

            foreach (var i in incomes)
            {
                list.Add(i);
            }

            return list;
        }

        public List<object> GetByFilter(int month, int year)
        {           
            string[] parsedLine;

            var incomes = new List<Income>();
            List<object> list = new List<object>();
            var lines = File.ReadLines(Directory + "income.txt");
            foreach (var line in lines)
            {
                parsedLine = line.Split(' ');
                if (Convert.ToInt32(parsedLine[6]) == month && Convert.ToInt32(parsedLine[7]) == year)
                {
                    var income = new Income();
                    income.Id = Convert.ToInt64(parsedLine[0]);
                    income.Description = parsedLine[1];
                    income.Price = Convert.ToDouble(parsedLine[2]);
                    income.Quantity = Convert.ToInt32(parsedLine[3]);
                    income.Amount = Convert.ToDouble(parsedLine[4]);
                    income.Day = Convert.ToInt32(parsedLine[5]);
                    income.Month = Convert.ToInt32(parsedLine[6]);
                    income.Year = Convert.ToInt32(parsedLine[7]);
                    incomes.Add(income);
                }
            }

            foreach (var i in incomes)
            {
                list.Add(i);
            }

            return list;
        }

        public object GetByID(long id)
        {
            Income income = new Income();
            string[] parsedLine;
            var lines = File.ReadLines(Directory + "income.txt");
            foreach (var line in lines)
            {
                parsedLine = line.Split(' ');
                if (Convert.ToInt64(parsedLine[0]) == id)
                {
                    income.Id = Convert.ToInt64(parsedLine[0]);
                    income.Description = parsedLine[1];
                    income.Price = Convert.ToDouble(parsedLine[2]);
                    income.Quantity = Convert.ToInt32(parsedLine[3]);
                    income.Amount = Convert.ToDouble(parsedLine[4]);
                    income.Day = Convert.ToInt32(parsedLine[5]);
                    income.Month = Convert.ToInt32(parsedLine[6]);
                    income.Year = Convert.ToInt32(parsedLine[7]);
                    break;
                }
                else
                {
                    income = null;
                }
            }

            return income;
        }

        public void Insert(object item)
        {
            List<Income> inc = new List<Income>();
            List<object> list = new List<object>(GetAll());
            foreach (var o in list)
            {
                inc.Add((Income)o);
            }

            foreach (var i in inc)
            {
                AutoincrementId = i.Id + 1;
            }

            Income income = new Income();
            income = (Income)item;

            File.AppendAllText(Directory + "income.txt", MakeString(income));
        }

        private string MakeString(Income income)
        {
            return AutoincrementId + " " + income.Description + " " + income.Price + " " + income.Quantity + " " + income.Amount + " " + income.Day + " " + income.Month + " " + income.Year + "\n";
        }

        public void Update(object item)
        {
            throw new NotImplementedException();
        }
    }
}
