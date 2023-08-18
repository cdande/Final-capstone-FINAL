using Capstone.Exceptions;
using Capstone.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Security.Cryptography.Xml;

namespace Capstone.DAO
{
    public class PlayerSqlDao:IPlayerDao
    {
        private readonly string connectionString;

        public PlayerSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Player> GetPlayersByGameId(int id)
        {
            IList<Player> players = new List<Player>();

            string sql = "Select * FROM players p JOIN player_game pg on p.player_id= pg.player_id JOIN game g on g.game_id = pg.game_id WHERE game_id=@id";

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
                        Player player = MapRowToPlayer(reader);
                        players.Add(player);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return players;
        }
        public List<Player> CreatePlayers(List<Player> players)
        {
            List<Player> addedPlayers = new List<Player>();
            Player newPlayer = null;
            string sql = "INSERT INTO players (username, select_character, money, player_position, is_rolled, is_turn, stock_value) " +
                "OUTPUT INSERTED.player_id " +
                "VALUES (@username, @select_character, @money, @player_position, @is_rolled, @is_turn, @stock_value)";

            try
            {
                foreach (Player player in players)
                {



                    int newPlayerId;
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@username", player.Username);
                        cmd.Parameters.AddWithValue("@select_character", player.SelectCharacter);
                        cmd.Parameters.AddWithValue("@money", player.Money);
                        cmd.Parameters.AddWithValue("@player_position", player.Position);
                        cmd.Parameters.AddWithValue("@is_rolled", player.IsRolled);
                        cmd.Parameters.AddWithValue("@is_turn", player.IsTurn);
                        cmd.Parameters.AddWithValue("@stock_value", player.StockValue);


                        newPlayerId = Convert.ToInt32(cmd.ExecuteScalar());

                    }

                    newPlayer = GetPlayerByPlayerId(newPlayerId);
                    addedPlayers.Add(newPlayer);
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }
            return addedPlayers;
        }
       
        public Player GetPlayerByPlayerId(int id)
        {
            Player player = null;
            string sql = "SELECT * FROM players " +
                "WHERE player_id = @player_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@player_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        player = MapRowToPlayer(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return player;
        }
        public Player UpdatePlayer(Player player)
        {
            Player updatedPlayer = null;
            string sql = "UPDATE players SET username = @username, " +
                "select_character = @select_character, " +
                "money = @money, " +
                "player_position = @position, " +
                "is_rolled = @isRolled, " +
                "is_turn = @isTurn, " +
                "stock_value = @stock_value " +
                "WHERE player_id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", player.Username);
                    cmd.Parameters.AddWithValue("@select_character", player.SelectCharacter);
                    cmd.Parameters.AddWithValue("@money", player.Money);
                    cmd.Parameters.AddWithValue("@position", player.Position);
                    cmd.Parameters.AddWithValue("@isRolled", player.IsRolled);
                    cmd.Parameters.AddWithValue("@isTurn", player.IsTurn);
                    cmd.Parameters.AddWithValue("@id", player.PlayerId);
                    cmd.Parameters.AddWithValue("@stock_value", player.StockValue);

                    int numberOfRows = cmd.ExecuteNonQuery();
                    if (numberOfRows == 0)
                    {
                        throw new DaoException("Zero rows affected, expected at least one");
                    }
                }
                updatedPlayer = GetPlayerByPlayerId(player.PlayerId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return updatedPlayer;

        }
        private Player MapRowToPlayer(SqlDataReader reader)
        {
            Player player = new Player();
            player.PlayerId = Convert.ToInt32(reader["player_id"]);
            player.Username = Convert.ToString(reader["username"]);
            player.SelectCharacter = Convert.ToString(reader["select_character"]);
            player.Money = Convert.ToInt32(reader["money"]);
            player.Position = Convert.ToInt32(reader["player_position"]);
            player.IsRolled = Convert.ToBoolean(reader["is_rolled"]);
            player.IsTurn = Convert.ToBoolean(reader["is_turn"]);
            player.StockValue = Convert.ToInt32(reader["stock_value"]);

            return player;
        }
    }
    }

