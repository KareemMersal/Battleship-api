using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BattleShip.Api.Features.Games
{
    [Route("api/" + Constants.ApiVersion.V1 + "/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IBoardService _service;
        public BoardController(ILogger<BoardController> logger, IBoardService service)
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
        [HttpPost("CreateGame")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Post(CreateGameRequest request)
        {
            var result = await _service.CreateGame(request);
            if (!result.Equals(default(KeyValuePair<Guid, Guid>))) // # of rows inserted
            {
                _logger.LogInformation("Game Created", request);
                return Created("CreateGame", new
                {
                    BoardOneId = result.Key , 
                    BoardTwoId = result.Value
                });
            }
            else
            {
                _logger.LogError("Error Created Game", request);
                return  new StatusCodeResult(409);
            }
        }
    }
}