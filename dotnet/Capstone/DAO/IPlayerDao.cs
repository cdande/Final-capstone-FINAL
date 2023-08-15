using Capstone.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPlayerDao
    {
        public IList<Player> GetPlayersByGameId(int id);
        public Player CreatePlayer(Player player);
        public Player UpdatePlayer(Player player);
        public Player GetPlayerByPlayerId(int id);


    }
}
