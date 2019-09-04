using System;
using System.ComponentModel.DataAnnotations;

namespace BattleShip.Api.Features.Games
{
    public class CreateGameRequest
    {
        /// <summary>
        /// Player One Id
        /// </summary>
        [Required]
        public Guid PlayerOne { get; set; }

        /// <summary>
        /// Player Two Id
        /// </summary>
        [Required]
        public Guid PlayerTwo { get; set; }
        
        /// <summary>
        /// The board size. Range Must be between 5 and 25
        /// </summary>
        public int BoardSize { get; set; } = 10;
    }
}
