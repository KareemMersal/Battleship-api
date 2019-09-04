using AutoMapper;
using Battleship.api.Domain;
using Battleship.api.Features.Player;

namespace BattleShip.Api.Features.Games
{
    public class PlayerShootMapperProfile : Profile
    {
        public PlayerShootMapperProfile()
        {
            CreateMap<PlayerShootResponse, PlayerShootReport>();
        }
    }
}
