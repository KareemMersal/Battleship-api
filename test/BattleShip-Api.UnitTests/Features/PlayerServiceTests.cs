using System;
using System.Collections.Generic;
using System.Drawing;
using BattleShip.Api.CustomExceptions;
using BattleShip.Api.Domain;
using BattleShip.Api.Features.Games;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace BattleShip_Api.UnitTests.Features
{
   public class PlayerServiceTests
    {
        private readonly Mock<IBoardRepository> _repo;
        private readonly Mock<ILogger<PlayerService>> _logger;

        public PlayerServiceTests()
        {
            _logger = new Mock<ILogger<PlayerService>>();
            _repo = new Mock<IBoardRepository>();
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(-1, 1)]
        [InlineData(1 , 1)]
        [InlineData(26, 1)]
        public void Create_Board_Wrong_BoardSize_Should_Return_Error(int x , int y)
        {
            var board = SetupData();
            
            var playerService = new PlayerService(_repo.Object, _logger.Object);
                playerService.IsLocationsValid(board , new List<Point> {new Point(x,y)}).ShouldBe(false);
        }
        [Fact]
        public void Check_Random_Function()
        {
            var boardId = Guid.NewGuid();
            var board = new Board(Guid.NewGuid(), 5);
            board.BoardId = boardId;

            SetupMock(board);
            var playerService = new PlayerService(_repo.Object, _logger.Object);
            var result = playerService.RandomiseShips(boardId);
        }
        private void SetupMock(Board board)
        {
            _repo.Setup(c => c.AddBoard(board))
                .ReturnsAsync(1);

            _repo.Setup(c => c.CheckBoardExists(board.BoardId))
                .ReturnsAsync(true);

            _repo.Setup(c => c.GetBoard(board.BoardId))
                .ReturnsAsync(board);
        }
        private Board SetupData()
        {
           var board = new Board(Guid.NewGuid(), 5);
            var ship = new Ship(2, false);
            ship.Cells.Add(new Cell(new Point(1, 1), Guid.NewGuid()));
            board.Ships.Add(ship);
            return board;
        }
    }
}
