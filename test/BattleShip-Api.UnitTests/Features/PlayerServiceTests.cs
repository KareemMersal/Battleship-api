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
                playerService.PlaceShipOnBoard(board , new List<Point> {new Point(x,y)}).ShouldBe(false);
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
