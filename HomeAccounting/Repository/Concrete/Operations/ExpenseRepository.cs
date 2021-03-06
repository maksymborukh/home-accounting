﻿using Models.Entities;
using Repository.Abstract;
using Repository.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repository.Concrete.Operations
{
    public class ExpenseRepository : IRepository
    {
        DBManager dbManager = new DBManager("account");
        IDbConnection connection = null;

        public void Insert(object expense)
        {
            string commandText = "insert into expense (Description, Price, Quantity, Amount, Day, Month, Year)" +
                 "values (@Description, @Price, @Quantity, @Amount, @Day, @Month, @Year);";
            dbManager.Insert(commandText, CommandType.Text, Param((Expense)expense).ToArray());
        }

        public void Delete(long Id)
        {
            var parameters = new List<IDbDataParameter>
            {
                dbManager.CreateParameter("@Id", Id, DbType.Int64)
            };

            string commandText = "delete from expense where Id = @Id;";
            dbManager.Delete(commandText, CommandType.Text, parameters.ToArray());
        }

        public List<object> GetAll()
        {
            string commandText = "select * from expense";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, null, out connection);
            try
            {
                var expenses = new List<Expense>();
                List<object> list = new List<object>();
                while (dataReader.Read())
                {
                    var expense = new Expense();
                    expense.Id = Convert.ToInt64(dataReader["Id"]);
                    expense.Description = dataReader["Description"].ToString();
                    expense.Price = Convert.ToDouble(dataReader["Price"]);
                    expense.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                    expense.Amount = Convert.ToDouble(dataReader["Amount"]);
                    expense.Day = Convert.ToInt32(dataReader["Day"]);
                    expense.Month = Convert.ToInt32(dataReader["Month"]);
                    expense.Year = Convert.ToInt32(dataReader["Year"]);
                    expenses.Add(expense);
                }

                foreach (var e in expenses)
                {
                    list.Add(e);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataReader.Close();
                dbManager.CloseConnection(connection);
            }
        }

        public List<object> GetByFilter(int month, int year)
        {
            string commandText = $"select * from expense where Month = {month} and Year = {year}";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, null, out connection);
            try
            {
                var expenses = new List<Expense>();
                List<object> list = new List<object>();
                while (dataReader.Read())
                {
                    var expense = new Expense();
                    expense.Id = Convert.ToInt64(dataReader["Id"]);
                    expense.Description = dataReader["Description"].ToString();
                    expense.Price = Convert.ToDouble(dataReader["Price"]);
                    expense.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                    expense.Amount = Convert.ToDouble(dataReader["Amount"]);
                    expense.Day = Convert.ToInt32(dataReader["Day"]);
                    expense.Month = Convert.ToInt32(dataReader["Month"]);
                    expense.Year = Convert.ToInt32(dataReader["Year"]);
                    expenses.Add(expense);
                }

                foreach (var e in expenses)
                {
                    list.Add(e);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataReader.Close();
                dbManager.CloseConnection(connection);
            }
        }

        public object GetByID(long id)
        {
            var parameters = new List<IDbDataParameter>
            {
                dbManager.CreateParameter("@Id", id, DbType.Int64)
            };

            string commandText = "select * from expense where Id = @Id;";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, parameters.ToArray(), out connection);
            try
            {
                var expense = new Expense();
                while (dataReader.Read())
                {
                    expense.Id = Convert.ToInt64(dataReader["Id"]);
                    expense.Description = dataReader["Description"].ToString();
                    expense.Price = Convert.ToDouble(dataReader["Price"]);
                    expense.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                    expense.Amount = Convert.ToDouble(dataReader["Amount"]);
                    expense.Day = Convert.ToInt32(dataReader["Day"]);
                    expense.Month = Convert.ToInt32(dataReader["Month"]);
                    expense.Year = Convert.ToInt32(dataReader["Year"]);
                }

                return expense;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataReader.Close();
                dbManager.CloseConnection(connection);
            }
        }

        public void Update(object expense)
        {
            string commandText = "update expense set Description = @Description, Price = @Price, Quantity = @Quantity," +
                " Amount = @Amount, Day = @Day, Month = @Month, Year = @Year where Id = @Id;";
            dbManager.Update(commandText, CommandType.Text, Param((Expense)expense).ToArray());
        }

        public List<IDbDataParameter> Param(Expense expense)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", expense.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Description", 50, expense.Description, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Price", expense.Price, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Quantity", expense.Quantity, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Amount", expense.Amount, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Day", expense.Day, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Month", expense.Month, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Year", expense.Year, DbType.Int32));

            return parameters;
        }
    }
}
