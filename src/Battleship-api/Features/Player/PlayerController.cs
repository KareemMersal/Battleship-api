using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShip.Api;
using BattleShip.Api.Features.Games;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Battleship_Api.Features.Player
{
    [Route("api/" + Constants.ApiVersion.V1 + "/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerService _service;
        public PlayerController(ILogger<PlayerController> logger, IPlayerService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Create a New Game add the number of ships and the board size while Creating.
        /// however the defaults will be used if not provided.board number as Unique id to allow the system to use multiple boards in the same time.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /Games
        ///     {
        ///         "boardSize": "board-size",
        ///         "PlayerOne" :"Player-One-Id",
        ///         "PlayerTwo" : "Player-Two-Id"
        ///     }
        /// </remarks>
        /// <param name="request">create game model</param>
        /// <response code="201">Returns the ids of the created Board</response>
        /// <response code="400">Returns request is invalid</response>
        /// <response code="409">Returns Error about placing the Ship</response>
        [HttpPost("PlaceShip")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Post(PlaceShipRequest request)
        {
            var result = await _service.PlaceShip(request);
            if (!result.Equals(default(KeyValuePair<Guid, Guid>))) 
            {
                _logger.LogInformation("Ship Placed", request);
                return Created("Ship Placed", new
                {
                    BoardId = result.Key,
                    ShipId = result.Value
                });
            }
            else
            {
                _logger.LogError("Error Created Game", request);
                return new StatusCodeResult(409);
            }
        }
    }
}