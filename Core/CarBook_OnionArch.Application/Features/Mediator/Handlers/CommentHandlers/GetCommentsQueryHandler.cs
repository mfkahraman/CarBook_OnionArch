using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.CommentQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentsQueryHandler(IRepository<Comment> repository,
                                        IMapper mapper)
        : IRequestHandler<GetCommentsQuery, List<GetCommentsQueryResult>>
    {
        public async Task<List<GetCommentsQueryResult>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();

            if (values == null || values.Count == 0)
            {
                throw new Exception("Dbde hiç kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }

            return mapper.Map<List<GetCommentsQueryResult>>(values);
        }
    }
}