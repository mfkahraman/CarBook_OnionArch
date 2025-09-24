using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler(IRepository<Author> repository,
                                        IMapper mapper)
        : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetAuthorByIdQueryResult>(entity);
        }
    }
}