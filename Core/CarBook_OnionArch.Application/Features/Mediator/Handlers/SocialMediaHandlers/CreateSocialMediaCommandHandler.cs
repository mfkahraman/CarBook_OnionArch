using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateSocialMediaCommand, GetSocialMediaByIdQueryResult>
    {
        public async Task<GetSocialMediaByIdQueryResult> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<SocialMedia>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetSocialMediaByIdQueryResult>(entity);
        }
    }
}