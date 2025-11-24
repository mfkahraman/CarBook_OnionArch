using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.MessageCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.MessageResults;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Mappings
{
    public class MessageMappingProfile : Profile
    {
        public MessageMappingProfile()
        {
            CreateMap<Message, CreateMessageCommand>().ReverseMap();
            CreateMap<Message, GetMessagesListQueryResult>();
        }
    }
}
