using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.BlogQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsWithDetailsQueryHandler(IBlogRepository repository,
                                        IMapper mapper)
        : IRequestHandler<GetBlogsWithDetailsQuery, List<GetBlogsWithDetailsQueryResult>>
    {
        public async Task<List<GetBlogsWithDetailsQueryResult>> Handle(GetBlogsWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetBlogsWithDetailsAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetBlogsWithDetailsQueryResult>>(values);
        }
    }
}