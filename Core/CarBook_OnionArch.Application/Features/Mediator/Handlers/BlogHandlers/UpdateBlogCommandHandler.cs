using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.BlogCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler(IRepository<Blog> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateBlogCommand, bool>
    {
        public async Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Blog>(request);
            repository.Update(entity);
            var result = await unitOfWork.CommitAsync();
            if (!result)
            {
                throw new Exception("Db güncelleme işlemi sırasında bir sorun oluştu.");
            }
            return true;
        }
    }
}