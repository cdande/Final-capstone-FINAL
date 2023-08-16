using Capstone.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPlayerDao
    {
        public IList<Player> GetPlayersByGameId(int id);
        public List<Player> CreatePlayers(List<Player> players);
        public Player UpdatePlayer(Player player);
        public Player GetPlayerByPlayerId(int id);


    }
}
