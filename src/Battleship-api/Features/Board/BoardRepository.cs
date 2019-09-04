using System;
using System.Threading.Tasks;
using BattleShip.Api.CustomExceptions;
using BattleShip.Api.Database;
using BattleShip.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BattleShip.Api.Features.Games
{
    internal class BoardRepository : IBoardRepository
    {
        private readonly BattleShipDbContext _context;
        private readonly ILogger<BoardRepository> _logger;

        public BoardRepository(BattleShipDbContext context, ILogger<BoardRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> AddBoard(Board board)
        {
            try
            {
                _context.Boards.Add(board);
                return await _context.SaveChangesAsync();
            }
            catch (Exception e) when (e.HResult == -2147024809) // Game Already Exists in the Database
            {
                _logger.LogError("Board Already Exists", board);
                throw new DuplicateEntryException("Board");
            }

            catch (Exception e)
            {
                _logger.LogError("Insert Game Failed", board);
                throw new InsertFailedException("Game" , e.Message);
            }
            
        }
    }
}
