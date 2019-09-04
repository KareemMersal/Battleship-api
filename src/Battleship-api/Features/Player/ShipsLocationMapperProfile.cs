using AutoMapper;
using Battleship.api.Domain;

namespace Battleship.api.Features.Player
{
    public class ShipsLocationMapperProfile : Profile
    {
        public ShipsLocationMapperProfile()
        {
            CreateMap<ShipsLocationResponse, ShipsLocation>().ReverseMap();
        }
    }
}
