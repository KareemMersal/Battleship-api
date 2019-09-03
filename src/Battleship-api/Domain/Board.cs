using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleShip.Api.Domain
{
    public class Board
    {
        //Table Id Only 
        [Key]
        public Guid BoardId { get; set; }
        public Board(Guid playerId, int boardSize , ICollection<Ship> ships)
        {
            BoardId = Guid.NewGuid();
            PlayerId = playerId;
            BoardSize = boardSize;
            Ships = ships;
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
