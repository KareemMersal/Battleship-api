using System;
using System.Threading.Tasks;
using BattleShip.Api.Domain;

namespace BattleShip.Api.Features.Games
{
    public interface IBoardRepository
    {
        Task<int> AddBoard(Board board);
        Task<bool> CheckBoardAndPlayer(Guid boardId, Guid playerId);
        Task<bool> CheckBoardExists(Guid boardId);
        Task<Board> GetBoard(Guid boardId, Guid playerId);
        Task<Board> GetBoard(Guid boardId);
        Task<int> UpdateBoard(Board selectedBoard);

    }
}
