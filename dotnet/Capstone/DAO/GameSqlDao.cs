using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class GameSqlDao : IGameDao
    {
        private readonly string connectionString;

        public GameSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Game> GetGamesByUserId(int id)
        {
            IList<Game> games = new List<Game>();

            string sql = "SELECT * FROM games WHERE user_id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Game game = MapRowToGame(reader);
                        games.Add(game);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return games;
        }

        public Game GetGameByGameId (int gameId)
        {
            Game game = null;

            string sql = "SELECT * FROM games WHERE game_id = @game_id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@game_id", gameId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        game = MapRowToGame(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return game;
        }

        public Game UpdateGameByGameId(Game game)
        {
            Game updatedGame = null;

            string sql = "UPDATE games SET title = @game.Title, is_in_progress = @game.IsInProgress, max_turns = @game.MaxTurns," +
                         "current_turn = @game.CurrentTurn FROM users WHERE game_id = @game.GameId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@game.Title", game.Title);
                    cmd.Parameters.AddWithValue("@game.IsInProgress", game.IsInProgress);
                    cmd.Parameters.AddWithValue("@game.MaxTurns", game.MaxTurns);
                    cmd.Parameters.AddWithValue("@game.CurrentTurn", game.CurrentTurn);
                    cmd.Parameters.AddWithValue("@game.GameId", game.GameId);
                    int numberOfRows = cmd.ExecuteNonQuery();

                    if (numberOfRows == 0)
                    {
                        throw new DaoException("Zero rows affected, expected at least one.");
                    }
                     }
                        updatedGame = GetGameByGameId(game.GameId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return updatedGame;
        }

        public Game CreateGame(Game game)
        {
            Game newGame = null;

            
            string sql = "INSERT INTO games (title, is_in_progress, max_turns, current_turn, user_id) " +
                         "OUTPUT INSERTED.game_id " +
                         "VALUES (@game.Title, @game.IsInProgress, @game.MaxTurns, @game.CurrentTurn, @game.UserId)";

            int newGameId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@game.Title", game.Title);
                    cmd.Parameters.AddWithValue("@game.IsInProgress", game.IsInProgress);
                    cmd.Parameters.AddWithValue("@game.MaxTurns", game.MaxTurns);
                    cmd.Parameters.AddWithValue("@game.CurrentTurn", game.CurrentTurn);
                    cmd.Parameters.AddWithValue("@game.UserId", game.UserId);
                    newGameId = Convert.ToInt32(cmd.ExecuteScalar());

                }
                newGame = GetGameByGameId(newGameId);
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return newGame;
        }
        private Game MapRowToGame(SqlDataReader reader)
        {
            Game game = new Game();
            game.GameId = Convert.ToInt32(reader["game_id"]);
            game.Title = Convert.ToString(reader["title"]);
            game.IsInProgress = Convert.ToBoolean(reader["is_in_progress"]);
            game.MaxTurns = Convert.ToInt32(reader["max_turns"]);
            game.CurrentTurn = Convert.ToInt32(reader["current_turn"]);
            return game;
        }
    }
}
