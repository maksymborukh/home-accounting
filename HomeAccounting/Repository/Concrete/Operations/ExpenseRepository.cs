﻿using Models.Entities;
using Repository.Abstract;
using Repository.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace Repository.Concrete.Operations
{
    public class ExpenseRepository : IExpenseRepository
    {
        DBManager dbManager = new DBManager("account");
        IDbConnection connection = null;

        public void Insert(Expense expense)
        {
            string commandText = "insert into expense (Description, Price, Quantity, Amount, Percent, Date)" +
                 "values (@Description, @Price, @Quantity, @Amount, @Percent, @Date);";
            dbManager.Insert(commandText, CommandType.Text, Param(expense).ToArray());
        }

        public void Delete(long Id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", Id, DbType.Int64));

            string commandText = "delete from expense where Id = @Id;";
            dbManager.Delete(commandText, CommandType.Text, parameters.ToArray());
        }

        public ObservableCollection<Expense> GetAll()
        {
            string commandText = "select * from expense";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, null, out connection);
            try
            {
                var expenses = new ObservableCollection<Expense>();
                while (dataReader.Read())
                {
                    var expense = new Expense();
                    expense.Id = Convert.ToInt64(dataReader["Id"]);
                    expense.Description = dataReader["Description"].ToString();
                    expense.Price = Convert.ToDouble(dataReader["Price"]);
                    expense.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                    expense.Amount = Convert.ToDouble(dataReader["Amount"]);
                    expense.Percent = Convert.ToDouble(dataReader["Percent"]);
                    expense.Date = dataReader["Date"].ToString();
                    expenses.Add(expense);
                }

                return expenses;
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

        public Expense GetByID(long id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

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
                    expense.Percent = Convert.ToDouble(dataReader["Percent"]);
                    expense.Date = dataReader["Date"].ToString();
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

        public void Update(Expense expense)
        {
            string commandText = "update expense set Description = @Description, Price =@Price, Quantity = @Quantity, Amount = @Amount, Percent = @Percent, Date = @Date where Id = @Id;";
            dbManager.Update(commandText, CommandType.Text, Param(expense).ToArray());
        }

        public List<IDbDataParameter> Param(Expense expense)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", expense.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Description", 50, expense.Description, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Price", expense.Price, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Quantity", expense.Quantity, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Amount", expense.Amount, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Percent", expense.Percent, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Date", 50, expense.Date, DbType.String));

            return parameters;
        }
    }
}
