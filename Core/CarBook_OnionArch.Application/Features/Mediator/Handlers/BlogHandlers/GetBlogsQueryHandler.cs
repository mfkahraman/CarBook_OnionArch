using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.BlogQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsQueryHandler(IRepository<Blog> repository,
                                        IMapper mapper)
        : IRequestHandler<GetBlogsQuery, List<GetBlogsQueryResult>>
    {
        public async Task<List<GetBlogsQueryResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetBlogsQueryResult>>(values);
        }
    }
}