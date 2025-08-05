using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class FooterAddressMappingProfile : Profile
    {
        public FooterAddressMappingProfile()
        {
            CreateMap<FooterAddress, CreateFooterAddressCommand>().ReverseMap();
            CreateMap<FooterAddress, UpdateFooterAddressCommand>().ReverseMap();
            CreateMap<FooterAddress, GetFooterAddressByIdQueryResult>();
            CreateMap<FooterAddress, GetFooterAddressQueryResult>();
        }
    }
}
