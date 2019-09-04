using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleShip.Api.Domain
{
    public class Ship
    {
        public Ship(int size, bool isDestroyed=false)
        {
            Size = size;
            Cells = new List<Cell>();
            ShipId = Guid.NewGuid();
            IsDestroyed = isDestroyed;
        }

        [Key]
        public Guid ShipId { get; set; }
        public int Size { get; set; }
        [Required]
        public Guid BoardId { get; set; }

        [Required]
        public Board Board { get; set; }

        [Required]
        public virtual ICollection<Cell> Cells { get; set; }

        [Required] public bool IsDestroyed { get; set; } = false;

    }
}
