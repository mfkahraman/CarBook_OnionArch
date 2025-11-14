using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.RentalCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.RentalResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class RentalMappingProfile : Profile
    {
        public RentalMappingProfile()
        {
            CreateMap<Rental, CreateRentalCommand>().ReverseMap();
            CreateMap<Rental, GetRentalQueryResult>();
        }
    }
}
