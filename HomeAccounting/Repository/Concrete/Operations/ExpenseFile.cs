using Models.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.Concrete.Operations
{
    public class ExpenseFile : IRepository
    {
        private long AutoincrementId = 0;
        private string Directory = AppDomain.CurrentDomain.BaseDirectory;

        public void Delete(long Id)
        {
            string[] parsedLine;

            var expenses = new List<Expense>();
            List<object> list = new List<object>();
            var lines = File.ReadLines(Directory + "expense.txt");
            foreach (var line in lines)
            {
                parsedLine = line.Split(' ');

                var expense = new Expense();
                expense.Id = Convert.ToInt64(parsedLine[0]);
                expense.Description = parsedLine[1];
                expense.Price = Convert.ToDouble(parsedLine[2]);
                expense.Quantity = Convert.ToInt32(parsedLine[3]);
                expense.Amount = Convert.ToDouble(parsedLine[4]);
                expense.Day = Convert.ToInt32(parsedLine[5]);
                expense.Month = Convert.ToInt32(parsedLine[6]);
                expense.Year = Convert.ToInt32(parsedLine[7]);
                expenses.Add(expense);
            }

            File.WriteAllText(Directory + "expense.txt", string.Empty);

            foreach (var expense in expenses)
            {
                if (expense.Id != Id)
                {
                    File.AppendAllText(Directory + "expense.txt", MakeString(expense));
                }
            }
        }

        public List<object> GetAll()
        {
            string[] parsedLine;

            var expenses = new List<Expense>();
            List<object> list = new List<object>();
            var lines = File.ReadLines(Directory + "expense.txt");
            foreach (var line in lines)
            {
                parsedLine = line.Split(' ');

                var expense = new Expense();
                expense.Id = Convert.ToInt64(parsedLine[0]);
                expense.Description = parsedLine[1];
                expense.Price = Convert.ToDouble(parsedLine[2]);
                expense.Quantity = Convert.ToInt32(parsedLine[3]);
                expense.Amount = Convert.ToDouble(parsedLine[4]);
                expense.Day = Convert.ToInt32(parsedLine[5]);
                expense.Month = Convert.ToInt32(parsedLine[6]);
                expense.Year = Convert.ToInt32(parsedLine[7]);
                expenses.Add(expense);
            }

            foreach (var i in expenses)
            {
                list.Add(i);
            }

            return list;
        }

        public List<object> GetByFilter(int month, int year)
        {
            string[] parsedLine;

            var expenses = new List<Expense>();
            List<object> list = new List<object>();
            var lines = File.ReadLines(Directory + "expense.txt");
            foreach (var line in lines)
            {
                parsedLine = line.Split(' ');
                if (Convert.ToInt32(parsedLine[6]) == month && Convert.ToInt32(parsedLine[7]) == year)
                {
                    var expense = new Expense();
                    expense.Id = Convert.ToInt64(parsedLine[0]);
                    expense.Description = parsedLine[1];
                    expense.Price = Convert.ToDouble(parsedLine[2]);
                    expense.Quantity = Convert.ToInt32(parsedLine[3]);
                    expense.Amount = Convert.ToDouble(parsedLine[4]);
                    expense.Day = Convert.ToInt32(parsedLine[5]);
                    expense.Month = Convert.ToInt32(parsedLine[6]);
                    expense.Year = Convert.ToInt32(parsedLine[7]);
                    expenses.Add(expense);
                }
            }

            foreach (var i in expenses)
            {
                list.Add(i);
            }

            return list;
        }

        public object GetByID(long id)
        {
            Expense expense = new Expense();
            string[] parsedLine;
            var lines = File.ReadLines(Directory + "expense.txt");
            foreach (var line in lines)
            {
                parsedLine = line.Split(' ');
                if (Convert.ToInt64(parsedLine[0]) == id)
                {
                    expense.Id = Convert.ToInt64(parsedLine[0]);
                    expense.Description = parsedLine[1];
                    expense.Price = Convert.ToDouble(parsedLine[2]);
                    expense.Quantity = Convert.ToInt32(parsedLine[3]);
                    expense.Amount = Convert.ToDouble(parsedLine[4]);
                    expense.Day = Convert.ToInt32(parsedLine[5]);
                    expense.Month = Convert.ToInt32(parsedLine[6]);
                    expense.Year = Convert.ToInt32(parsedLine[7]);
                    break;
                }
                else
                {
                    expense = null;
                }
            }

            return expense;
        }

        public void Insert(object item)
        {
            List<Expense> exp = new List<Expense>();
            List<object> list = new List<object>(GetAll());
            foreach (var o in list)
            {
                exp.Add((Expense)o);
            }

            foreach (var i in exp)
            {
                AutoincrementId = i.Id + 1;
            }

            Expense expense = new Expense();
            expense = (Expense)item;

            File.AppendAllText(Directory + "expense.txt", MakeString(expense));
        }

        private string MakeString(Expense expense)
        {
            return AutoincrementId + " " + expense.Description + " " + expense.Price + " " + expense.Quantity + " " + expense.Amount + " " + expense.Day + " " + expense.Month + " " + expense.Year + "\n";
        }

        public void Update(object item)
        {
            throw new NotImplementedException();
        }

    }
}
