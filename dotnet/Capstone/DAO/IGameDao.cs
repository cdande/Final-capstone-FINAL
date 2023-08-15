using Capstone.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IGameDao
    {
        public List<Game> GetGamesByUserId(int userId);
        public Game GetGameByGameId(int id);
        public Game UpdateGameByGameId(int id, Game game);
        public Game CreateGame(Game newGame); 
    }
}
