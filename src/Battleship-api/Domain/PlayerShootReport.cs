using System;
using BattleShip.Api.Features;

namespace Battleship.api.Domain
{
    public class PlayerShootReport : DataModel
    {
        public PlayerShootReport()
        {

        }

        public PlayerShootReport(Guid boardId)
        {
            BoardId = boardId;
        }
        public PlayerShootReport(Guid boardId, bool isHit, Guid shipId, bool isShipDestroyed, bool isGameLost)
        {
            BoardId = boardId;
            IsHit = isHit;
            ShipId = shipId;
            IsShipDestroyed = isShipDestroyed;
            IsGameLost = isGameLost;
        }

        public Guid BoardId { get; set; }

        public bool IsHit { get; set; }

        public Guid ShipId { get; set; }

        public bool IsShipDestroyed { get; set; }
        public bool IsGameLost { get; set; }
    }
}
