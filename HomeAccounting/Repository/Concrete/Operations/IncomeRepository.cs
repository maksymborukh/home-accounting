using Models.Entities;
using Repository.Abstract;
using Repository.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace Repository.Concrete.Operations
{
    public class IncomeRepository : IIncomeRepository
    {
        DBManager dbManager = new DBManager("account");
        IDbConnection connection = null;

        public void Insert(Income income)
        {
            string commandText = "insert into income (Description, Price, Quantity, Amount, Percent, Date)" +
                 "values (@Description, @Price, @Quantity, @Amount, @Percent, @Date);";
            dbManager.Insert(commandText, CommandType.Text, Param(income).ToArray());
        }

        public void Delete(long Id)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", Id, DbType.Int64));

            string commandText = "delete from income where Id = @Id;";
            dbManager.Delete(commandText, CommandType.Text, parameters.ToArray());
        }

        public List<Income> GetAll()
        {
            string commandText = "select * from income";
            var dataReader = dbManager.GetDataReader(commandText, CommandType.Text, null, out connection);
            try
            {
                var incomes = new List<Income>();
                while (dataReader.Read())
                {
                    var income = new Income();
                    income.Id = Convert.ToInt64(dataReader["Id"]);
                    income.Description = dataReader["Description"].ToString();
                    income.Price = Convert.ToDouble(dataReader["Price"]);
                    income.Quantity = Convert.ToInt32(dataReader["Quantity"]);
                    income.Amount = Convert.ToDouble(dataReader["Amount"]);
                    income.Percent = Convert.ToDouble(dataReader["Percent"]);
                    income.Date = dataReader["Date"].ToString();
                    incomes.Add(income);
                }

                return incomes;
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

        public Income GetByID(long id)
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
                    income.Percent = Convert.ToDouble(dataReader["Percent"]);
                    income.Date = dataReader["Date"].ToString();
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

        public void Update(Income income)
        {
            string commandText = "update income set Description = @Description, Price =@Price, Quantity = @Quantity, Amount = @Amount, Percent = @Percent, Date = @Date where Id = @Id;";
            dbManager.Update(commandText, CommandType.Text, Param(income).ToArray());
        }

        public List<IDbDataParameter> Param(Income income)
        {
            var parameters = new List<IDbDataParameter>();
            parameters.Add(dbManager.CreateParameter("@Id", income.Id, DbType.Int64));
            parameters.Add(dbManager.CreateParameter("@Description", 50, income.Description, DbType.String));
            parameters.Add(dbManager.CreateParameter("@Price", income.Price, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Quantity", income.Quantity, DbType.Int32));
            parameters.Add(dbManager.CreateParameter("@Amount", income.Amount, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Percent", income.Percent, DbType.Double));
            parameters.Add(dbManager.CreateParameter("@Date", 50, income.Date, DbType.String));

            return parameters;
        }
    }
}
