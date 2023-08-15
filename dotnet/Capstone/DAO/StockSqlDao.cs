using Capstone.Exceptions;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class StockSqlDao: IStockDao
    {
        private readonly string connectionString;

        public StockSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Stock> GetStocksByPlayerId(int id)
        {
            IList<Stock> stocks = new List<Stock>();

            string sql = "Select * FROM stocks s JOIN player_stock ps on s.stock_id= ps.stock_id JOIN players p on p.player_id = ps.player_id WHERE player_id=@id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Stock stock = MapRowToStock(reader);
                        stocks.Add(stock);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return stocks;
        }
        private Stock MapRowToStock(SqlDataReader reader)
        {
            Stock stock = new Stock();
            stock.StockId = Convert.ToInt32(reader["stock_id"]);
            stock.Price = Convert.ToInt32(reader["price"]);
            stock.Name = Convert.ToString(reader["name"]);
            stock.Fee = Convert.ToInt32(reader["fee"]);

            return stock;
        }
    }
}
