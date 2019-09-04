using System;
using System.Collections.Generic;
using System.Drawing;

namespace Battleship.api.Domain
{
    public class ShipsLocation
    {
        public Guid ShipId { get; set; }

        public List<Point> Location { get; set; }
    }
}
