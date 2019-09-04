using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BattleShip.Api;
using BattleShip.Api.Features.Games;
using Battleship.api.Features.Player;
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
        private readonly IMapper _mapper;

        public PlayerController(ILogger<PlayerController> logger, IPlayerService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Place a Ship by the location cells provided
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///
        ///     POST /Games
        ///     {
        ///         "playerId": "Player Id",
        ///         "boardId" :"board Id",
        ///         "shipLocation" : "ship Location"
        ///     }
        /// </remarks>
        /// <param name="request">Place Ship in Board model</param>
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

        /// <summary>
        /// Player Shoot a Cell.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /Games
        ///     {
        ///         "playerId": "Player Id",
        ///         "boardId" :"board Id",
        ///         "shipLocation" : "ship Location"
        ///     }
        /// </remarks>
        /// <param name="boardId">The Game Board Id</param>
        /// <param name="location">The Location of the Cell to be hit</param>
        /// <response code="201">Returns the ids of the created Board</response>
        /// <response code="400">Returns request is invalid</response>
        /// <response code="409">Returns Error about placing the Ship</response>
        [HttpPost("PlayerShoot")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Post(Guid boardId , Point location)
        {
            var result = await _service.PlayerShoot(boardId , location);
            if (result != null)
            {
                var report = _mapper.Map<PlayerShootResponse>(result);
                _logger.LogInformation("Player Shoot", report);
                return Created("Ship Placed", report);
            }
            else
            {
                _logger.LogError("Player Shooting Error");
                return new StatusCodeResult(409);
            }
        }
    }
}