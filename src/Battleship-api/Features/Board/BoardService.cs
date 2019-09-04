using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BattleShip.Api.Core.Extensions;
using BattleShip.Api.CustomExceptions;
using BattleShip.Api.Domain;
using Microsoft.Extensions.Logging;


namespace BattleShip.Api.Features.Games
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepo;
        private readonly ILogger<BoardService> _logger;
        public BoardService(
            IBoardRepository boardRepo, 
            ILogger<BoardService> logger)
        {
            _boardRepo = boardRepo;
            _logger = logger;
        }

        public async Task<KeyValuePair<Guid, Guid>> CreateGame(CreateGameRequest request)
        {
            //Create The Players Map
            var playerOneBoard = CreateBoard(request.PlayerOne, request.BoardSize);
            var playerTwoBoard = CreateBoard(request.PlayerTwo, request.BoardSize);
            
            //Validate Model
            var playerOneResult = ValidateModel(playerOneBoard);
            var playerTwoResult = ValidateModel(playerOneBoard);

            //Insert Models
            if (playerOneResult.isValid)
                await _boardRepo.AddBoard(playerOneBoard);
            else
            {
                _logger.LogError("Data Model Validation Failed", playerOneResult.results);
                throw new ValidationModelException(
                    "Board",
                    string.Join(" , ", playerOneResult.results.Select(x => x.ErrorMessage)));
            }

            if (playerTwoResult.isValid)
            {
                await _boardRepo.AddBoard(playerTwoBoard);
                return new KeyValuePair<Guid, Guid>(playerOneBoard.BoardId , playerTwoBoard.BoardId);
            }

            _logger.LogError("Data Model Validation Failed", playerOneResult.results);
            throw new ValidationModelException(
                "Board",
                string.Join(" , ", playerOneResult.results.Select(x => x.ErrorMessage)));
        }

        private Board CreateBoard(Guid playerId, int mapSize)
        {
            return new Board(playerId, mapSize);
        }

        (bool isValid, List<ValidationResult> results) ValidateModel(Board board)
        {
            var validator = new GameModelValidatorExt<Board>();
            var valueTuple = validator.TryValidation(board);
            return valueTuple;
        }
    }
}
