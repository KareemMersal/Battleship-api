using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BattleShip.Api.Features;

namespace BattleShip.Api.Domain
{
    public class Board : DataModel
    {
        //Table Id Only 
        [Key]
        public Guid BoardId { get; set; }
        public Board(Guid playerId, int boardSize)
        {
            BoardId = Guid.NewGuid();
            PlayerId = playerId;
            BoardSize = boardSize;
            Ships = new List<Ship>();
        }

        [Required]
        public Guid PlayerId { get; set; }

        [Required]
        public virtual ICollection<Ship> Ships { get; set; }

        [Range(5, 25,
            ErrorMessage = "Board Size must be between {1} and {2}.")]
        public int BoardSize { get; set; }
    }
}
