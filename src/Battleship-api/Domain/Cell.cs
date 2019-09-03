using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BattleShip.Api.Domain
{
    public class Cell
    {
        [Key] public Guid CellId { get; set; } 
        public Cell(Point cellAddress, Guid shipId, bool isDestroyed = false)
        {
            CellId = Guid.NewGuid();
            CellAddress = cellAddress;
            IsDestroyed = isDestroyed;
            ShipId = shipId;
        }

        [Required]
        public Guid ShipId { get; set; }

        [Required]
        public Ship Ship { get; set; }

        [Required]
        public Point CellAddress { get; set; }

        [Required]
        public bool IsDestroyed { get; set; }
    }
}
