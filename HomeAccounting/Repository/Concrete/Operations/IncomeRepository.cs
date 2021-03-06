﻿using Models.Entities;
using Repository.Abstract;
using Repository.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repository.Concrete.Operations
{
    public class IncomeRepository : IRepository
    {
        DBManager dbManager = new DBManager("account");
        IDbConnection connection = null;

        public void Insert(object income)
        {
            string commandText = "insert into income (Description, Price, Quantity, Amount, Day, Month, Year)" +
                 "values (@Description, @Price, @Quantity, @Amount, @Day, @Month, @Year);";
            dbManager.Insert(commandText, CommandType.Text, Param((Income)income).ToArray());
        }

        public void Delete(long Id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", Id, DbType.Int64));

            string commandText = "delete from income where Id = @Id;";
            dbManager.Delete(commandText, CommandType.Text, parameters.ToArray());
        }

        public List<object> GetAll()
        {
            string commandText = "select * from income";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, null, out connection);
            try
            {
                var incomes = new List<Income>();
                List<object> list = new List<object>();
                while (dataReader.Read())
                {
                    var income = new Income();
                    income.Id = Convert.ToInt64(dataReader["Id"]);
                    income.Description = dataReader["Description"].ToString();
                    income.Price = Convert.ToDouble(dataReader["Price"]);
                    income.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                    income.Amount = Convert.ToDouble(dataReader["Amount"]);
                    income.Day = Convert.ToInt32(dataReader["Day"]);
                    income.Month = Convert.ToInt32(dataReader["Month"]);
                    income.Year = Convert.ToInt32(dataReader["Year"]);
                    incomes.Add(income);  
                }

                foreach (var i in incomes)
                {
                    list.Add(i);
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
            string commandText = $"select * from income where Month = {month} and Year = {year}";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, null, out connection);
            try
            {
                var incomes = new List<Income>();
                List<object> list = new List<object>();
                while (dataReader.Read())
                {
                    var income = new Income();
                    income.Id = Convert.ToInt64(dataReader["Id"]);
                    income.Description = dataReader["Description"].ToString();
                    income.Price = Convert.ToDouble(dataReader["Price"]);
                    income.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                    income.Amount = Convert.ToDouble(dataReader["Amount"]);
                    income.Day = Convert.ToInt32(dataReader["Day"]);
                    income.Month = Convert.ToInt32(dataReader["Month"]);
                    income.Year = Convert.ToInt32(dataReader["Year"]);
                    incomes.Add(income);
                }

                foreach (var i in incomes)
                {
                    list.Add(i);
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
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", id, DbType.Int64));

            string commandText = "select * from income where Id = @Id;";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, parameters.ToArray(), out connection);
            try
            {
                var income = new Income();
                while (dataReader.Read())
                {
                    income.Id = Convert.ToInt64(dataReader["Id"]);
                    income.Description = dataReader["Description"].ToString();
                    income.Price = Convert.ToDouble(dataReader["Price"]);
                    income.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                    income.Amount = Convert.ToDouble(dataReader["Amount"]);
                    income.Day = Convert.ToInt32(dataReader["Day"]);
                    income.Month = Convert.ToInt32(dataReader["Month"]);
                    income.Year = Convert.ToInt32(dataReader["Year"]);
                }

                return income;
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

        public void Update(object income)
        {
            string commandText = "update income set Description = @Description, Price =@Price, Quantity = @Quantity, " +
                "Amount = @Amount, Day = @Day, Month = @Month, Year = @Year where Id = @Id;";
            dbManager.Update(commandText, CommandType.Text, Param((Income)income).ToArray());
        }

        public List<IDbDataParameter> Param(Income income)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", income.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Description", 50, income.Description, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Price", income.Price, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Quantity", income.Quantity, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Amount", income.Amount, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Day", income.Day, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Month", income.Month, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Year", income.Year, DbType.Int32));

            return parameters;
        }
    }
}
