using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorsQueryHandler(IRepository<Author> repository,
                                        IMapper mapper)
        : IRequestHandler<GetAuthorsQuery, List<GetAuthorsQueryResult>>
    {
        public async Task<List<GetAuthorsQueryResult>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetAuthorsQueryResult>>(values);
        }
    }
}