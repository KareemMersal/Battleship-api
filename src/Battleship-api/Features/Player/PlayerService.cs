using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using BattleShip.Api.CustomExceptions;
using Battleship.api.Domain;
using BattleShip.Api.Domain;
using Microsoft.Extensions.Logging;


namespace BattleShip.Api.Features.Games
{
    public class PlayerService : IPlayerService
    {
        private readonly IBoardRepository _boardRepo;
        private readonly ILogger<PlayerService> _logger;
        public PlayerService(
            IBoardRepository boardRepo, 
            ILogger<PlayerService> logger)
        {
            _boardRepo = boardRepo;
            _logger = logger;
        }

       public async Task<KeyValuePair<Guid, Guid>> PlaceShip(PlaceShipRequest request)
        {
            //Check if the Board and the Player are exists
            if (await _boardRepo.CheckBoardAndPlayer(request.BoardId, request.PlayerId))
            {
                //Get The Board Details
                var selectedBoard = await _boardRepo.GetBoard(request.BoardId, request.PlayerId);
                //Try Place the Ship into the Board
                if (PlaceShipOnBoard(selectedBoard, request.ShipLocation))
                {
                    //Save Changes
                    var ship = new Ship(request.ShipLocation.Count, false);
                    ship.Cells = request.ShipLocation.Select(
                        p => new Cell(p, ship.ShipId)).ToList();
                    selectedBoard.Ships.Add(ship);
                    await _boardRepo.UpdateBoard(selectedBoard);
                    return new KeyValuePair<Guid, Guid>(selectedBoard.BoardId , ship.ShipId);
                }
                else
                {
                    //Throw Exception
                    _logger.LogError("Invalid Ship Location Data", request);
                    throw new InvalidDataException(
                        "Ships", "Invalid Ship Location Data");
                }
                
            }
            else
                throw new InvalidDataException("Place Ship", "Wrong Inputs");
        }

       public async Task<PlayerShootReport> PlayerShoot(Guid boardId, Point location)
       {
           //Check if the Board and the Player are exists
            if (await _boardRepo.CheckBoardExists(boardId))
            {
                //Get Board 
                var board = await _boardRepo.GetBoard(boardId);
                var ship = TryShoot(board, location);
                var shootingReport = new PlayerShootReport(boardId);
                //Try Shoot
                if (ship  != null)
                {
                    //Shoot
                    ship.Cells.
                        First(c => c.CellAddress.X == location.X
                                   && c.CellAddress.Y == location.Y)
                        .IsDestroyed = true;

                    shootingReport.ShipId = ship.ShipId;
                    shootingReport.IsHit = true;

                    // Is Ship Destroyed 
                    ship.IsDestroyed = IsShipDestroyed(ship);
                    shootingReport.IsShipDestroyed = ship.IsDestroyed;
                    
                    // Is Game Lost 
                    shootingReport.IsGameLost = IsGameLost(board);

                    //Save
                    await _boardRepo.UpdateBoard(board);
                }
                else
                {
                    shootingReport.IsHit = false;
                    shootingReport.IsGameLost = false;
                    shootingReport.IsShipDestroyed = false;
                }

                return shootingReport;
            }

            throw new InvalidDataException("Player Shoot", "Wrong Inputs");
       }

       private bool IsGameLost(Board board)
       {
           return board.Ships.All(s => s.IsDestroyed);
       }

       private bool IsShipDestroyed(Ship ship)
       {
           return ship.Cells.All(c => c.IsDestroyed);
       }

       private Ship TryShoot(Board board, Point location)
       {
           return board.Ships.SingleOrDefault(ship => ship.Cells.Any(
               c => c.CellAddress.X == location.X && c.CellAddress.Y == location.X && !c.IsDestroyed));

       }

       public bool PlaceShipOnBoard(Board board, List<Point> points)
        {
            if (points == null || points.Count <= 0)
                return false;

            foreach (var point in points)
            {
                //Check if the Point within Board Range
                if (point.X - 1 > board.BoardSize || point.X <= 0 ||
                    point.Y - 1 > board.BoardSize || point.X <= 0)
                    return false;
                //Check if the point is not already Taken
                if (board.Ships.Any(ship => ship.Cells.Any(
                    c =>c.CellAddress.X == point.X && c.CellAddress.Y == point.X)))
                    return false;
            }

            return true;
        }
    }
}
