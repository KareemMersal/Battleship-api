using System;
using System.Threading.Tasks;
using BattleShip.Api.Domain;

namespace BattleShip.Api.Features.Games
{
    public interface IBoardRepository
    {
        Task<int> AddBoard(Board board);
    }
}
