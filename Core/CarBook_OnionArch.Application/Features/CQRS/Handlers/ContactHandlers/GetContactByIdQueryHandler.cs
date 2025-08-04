using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Queries.ContactQueries;
using CarBook_OnionArch.Application.Features.CQRS.Results.ContactResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler(IRepository<Contact> repository,
                                            IMapper mapper)
    {
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var entity = await repository.GetByIdAsync(query.Id);
            return mapper.Map<GetContactByIdQueryResult>(entity);
        }
    }
}
