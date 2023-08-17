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

        public List<Game> GetGamesByUserId(int id)
        {
            List<Game> games = new List<Game>();

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

        public Game GetGameByGameId(int gameId)
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

            string sql = "UPDATE games SET title = @Title, is_in_progress = @IsInProgress, max_turns = @MaxTurns," +
                         "current_turn = @CurrentTurn FROM users WHERE game_id = @GameId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Title", game.Title);
                    cmd.Parameters.AddWithValue("@IsInProgress", game.IsInProgress);
                    cmd.Parameters.AddWithValue("@MaxTurns", game.MaxTurns);
                    cmd.Parameters.AddWithValue("@CurrentTurn", game.CurrentTurn);
                    cmd.Parameters.AddWithValue("@GameId", game.GameId);
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
                         "VALUES (@Title, @IsInProgress, @MaxTurns, @CurrentTurn, @UserId)";

            int newGameId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Title", game.Title);
                    cmd.Parameters.AddWithValue("@IsInProgress", game.IsInProgress);
                    cmd.Parameters.AddWithValue("@MaxTurns", game.MaxTurns);
                    cmd.Parameters.AddWithValue("@CurrentTurn", game.CurrentTurn);
                    cmd.Parameters.AddWithValue("@UserId", game.UserId);
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
        public Game GetInProgressGameByUserId(int userId)
        {

            Game game = null;

            string sql = "SELECT * FROM games WHERE user_id= @user_id AND in_progress= 1";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
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
       
    

