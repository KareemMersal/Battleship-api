using System;
using BattleShip.Api.CustomExceptions;
using BattleShip.Api.Domain;
using BattleShip.Api.Features.Games;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace BattleShip_Api.UnitTests.Features
{
   public class BoardServiceTests
    {
        private readonly Mock<IBoardRepository> _repo;
        private readonly Mock<ILogger<BoardService>> _logger;

        public BoardServiceTests()
        {
            _logger = new Mock<ILogger<BoardService>>();
            _repo = new Mock<IBoardRepository>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(3)]
        [InlineData(26)]
        public void Create_Board_Wrong_BoardSize_Should_Return_Error(int boardSize)
        {
            var request = new CreateGameRequest
            {
                BoardSize = boardSize,
                PlayerOne = Guid.NewGuid(),
                PlayerTwo = Guid.NewGuid()
            };
            SetupMock(new Board(request.PlayerOne, boardSize));
            SetupMock(new Board(request.PlayerTwo, boardSize));
            var boardService = new BoardService(_repo.Object, _logger.Object);

            Should.Throw<ValidationModelException>(() =>
                boardService.CreateGame(request));
        }

      private void SetupMock(Board board)
        {
            _repo.Setup(c => c.AddBoard(board))
                .ReturnsAsync(1);
        }
    }
}
