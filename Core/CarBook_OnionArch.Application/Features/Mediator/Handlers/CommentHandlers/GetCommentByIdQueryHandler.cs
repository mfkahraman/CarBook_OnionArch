using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Queries.CommentQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.CommentResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByIdQueryHandler(IRepository<Comment> repository,
                                        IMapper mapper)
        : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Dbde kayıt bulunamadı veya dbden çekerken bir sorun oluştu.");
            }
            return mapper.Map<GetCommentByIdQueryResult>(entity);
        }
    }
}