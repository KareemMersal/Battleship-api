using System;

namespace Battleship.api.Features.Player
{
    public class PlayerShootResponse
    {
        public PlayerShootResponse(Guid boardId, bool isHit, Guid shipId, bool isShipDestroyed, bool isGameLost)
        {
            BoardId = boardId;
            IsHit = isHit;
            ShipId = shipId;
            IsShipDestroyed = isShipDestroyed;
            IsGameLost = isGameLost;
        }

        public Guid BoardId { get; }

        public bool IsHit { get; }

        public Guid ShipId { get; }

        public bool IsShipDestroyed { get; }
        public bool IsGameLost { get; }

    }
}
