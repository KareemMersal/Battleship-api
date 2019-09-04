using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Battleship.api.Domain;

namespace BattleShip.Api.Features.Games
{
    public interface IPlayerService
    {
        Task<KeyValuePair<Guid, Guid>> PlaceShip(PlaceShipRequest request);
        Task<PlayerShootReport> PlayerShoot(Guid boardId, Point location);
    }
}
