using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleShip.Api.Features.Games
{
    public interface IBoardService
    {
        Task<KeyValuePair<Guid, Guid>> CreateGame(CreateGameRequest request);
    }
}
