using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BattleShip.Api.Features.Games
{
    public class PlaceShipRequest
    {
        /// <summary>
        /// Player Id
        /// </summary>
        [Required]
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Player Board Id
        /// </summary>
        [Required]
        public Guid BoardId { get; set; }
        
        /// <summary>
        /// The Points Location s
        /// </summary>
        public List<Point> ShipLocation { get; set; }
    }
}
