using System;
using System.Collections.Generic;
using System.Drawing;

namespace Battleship.api.Features.Player
{
    public class ShipsLocationResponse
    {
        public Guid ShipId { get; set; }
        
        public List<Point> Location { get; set; }
    }
}


