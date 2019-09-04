using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleShip.Api.Features.Games
{
    public interface IPlayerService
    {
        Task<KeyValuePair<Guid, Guid>> PlaceShip(PlaceShipRequest request);
    }
}
