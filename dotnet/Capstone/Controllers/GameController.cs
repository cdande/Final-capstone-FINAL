using Capstone.DAO;
using Capstone.Exceptions;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace Capstone.Controllers
{
        [Route("game")]
        [ApiController]
        public class GameController : ControllerBase
        {
            
            private readonly IGameDao gameDao;

            public GameController(IGameDao gameDao)
            {
                
                this.gameDao = gameDao;
            }

            [HttpPost()]
            public IActionResult AddGame (Game newGame)
            {
                Game added = gameDao.CreateGame(newGame);
                return Created($"/game/{added.GameId}", added);
            }

            [HttpPut("{gameId}")]
            public ActionResult<Game> UpdateGame(Game gameToUpdate)
            {
                Game updatedGame = gameDao.UpdateGameByGameId(gameToUpdate);

                if(updatedGame != null)
                {
                    return Ok(updatedGame);
                }
                else
                {
                    return NotFound();
                }
            }
            [HttpGet("?userid={userId}")]
            public ActionResult<Game> GetInProgress(int userId)
            {
                Game game= gameDao.GetInProgressGameByUserId(userId);

                if (game != null)
                {
                    return Ok(game);
                }
                else
                {
                    return NotFound();
                }
            }


           
        }
    }

