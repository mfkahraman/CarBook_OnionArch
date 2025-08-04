using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Results.ContactResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler(IRepository<Contact> repository,
                                            IMapper mapper)
    {
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return mapper.Map<List<GetContactQueryResult>>(values);

        }
    }
}