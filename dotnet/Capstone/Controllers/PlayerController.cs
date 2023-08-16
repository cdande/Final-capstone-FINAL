using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace Capstone.Controllers

{
    [Route("player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        private readonly IPlayerDao PlayerDao;

        public PlayerController(IPlayerDao playerDao)
        {

            this.PlayerDao = playerDao;
        }

        [HttpPost()]
        public ActionResult<List<Player>> CreatePlayers(List<Player> newPlayers)
        {
            List<Player> players = PlayerDao.CreatePlayers(newPlayers);
            return Created($"/player", players);
        }
        [HttpPut("{playerId}")]
        public ActionResult<Game> UpdatePlayer(Player playerToUpdate)
        {
            Player updatedPlayer = PlayerDao.UpdatePlayer(playerToUpdate);

            if (updatedPlayer != null)
            {
                return Ok(updatedPlayer);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet()]
        public ActionResult<IList<Player>> GetPlayerByGameId(int gameId = 0)
        {
            IList<Player> players = PlayerDao.GetPlayersByGameId(gameId);
            if (players != null)
            {
                return Ok(players);
            }
            else
            {
                return NotFound();
            }

        }
    }
}


