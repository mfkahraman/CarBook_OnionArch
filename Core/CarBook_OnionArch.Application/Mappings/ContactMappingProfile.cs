using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.ContactCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.ContactResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Contact, GetContactQueryResult>();
            CreateMap<Contact, GetContactByIdQueryResult>();
        }
    }
}
