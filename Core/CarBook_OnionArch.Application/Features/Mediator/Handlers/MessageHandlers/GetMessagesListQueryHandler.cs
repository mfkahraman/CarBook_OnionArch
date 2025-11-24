using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.MessageQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.MessageResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.MessageHandlers
{
    internal class GetMessagesListQueryHandler(IRepository<Message> repository,
                                        IMapper mapper)
        : IRequestHandler<GetMessagesListQuery, List<GetMessagesListQueryResult>>
    {
        public async Task<List<GetMessagesListQueryResult>> Handle(GetMessagesListQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetMessagesListQueryResult>>(values);
        }
    }
}