using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.BlogQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler(IBlogRepository repository,
                                        IMapper mapper)
        : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetBlogByIdWithDetailsAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetBlogByIdQueryResult>(entity);
        }
    }
}