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
        public Player CreatePlayer(Player player)
        {
            Player addedPlayer = null;
            string sql = "INSERT INTO players (username, selected_character, money, player_position, is_rolled, is_turn) " +
                "OUTPUT INSERTED.player_id " +
                "VALUES (@username, @selected_character, @money, @player_position, @is_rolled, @s_turn)";

            try
            {
                int newPlayerId;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", player.PlayerId);
                    cmd.Parameters.AddWithValue("@selected_character", player.SelectedCharacter);
                    cmd.Parameters.AddWithValue("@money", player.Money);
                    cmd.Parameters.AddWithValue("@player_position", player.Position);
                    cmd.Parameters.AddWithValue("@is_rolled", player.IsRolled);
                    cmd.Parameters.AddWithValue("@is_turn", player.IsTurn);


                    newPlayerId = Convert.ToInt32(cmd.ExecuteScalar());

                }

                addedPlayer = GetPlayerByPlayerId(newPlayerId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return addedPlayer;
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
                "selected_character = @selected_character, " +
                "money = @money, " +
                "player_position = @position, " +
                "is_rolled = @is_rolled " +
                "is_turn = @is_turn " +
                "WHERE player_id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", player.Username);
                    cmd.Parameters.AddWithValue("@selected_character", player.SelectedCharacter);
                    cmd.Parameters.AddWithValue("@money", player.Money);
                    cmd.Parameters.AddWithValue("@position", player.Position);
                    cmd.Parameters.AddWithValue("@is_rolled", player.IsRolled);
                    cmd.Parameters.AddWithValue("@is_turn", player.IsTurn);
                  
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
            player.SelectedCharacter = Convert.ToString(reader["selected_character"]);
            player.Money = Convert.ToInt32(reader["money"]);
            player.Position = Convert.ToInt32(reader["player_position"]);
            player.IsRolled = Convert.ToBoolean(reader["is_rolled"]);
            player.IsTurn = Convert.ToBoolean(reader["is_turn"]);

            return player;
        }
    }
    }

