using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.BlogCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.BlogResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler(IRepository<Blog> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateBlogCommand, GetBlogByIdQueryResult>
    {
        public async Task<GetBlogByIdQueryResult> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Blog>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetBlogByIdQueryResult>(entity);
        }
    }
}