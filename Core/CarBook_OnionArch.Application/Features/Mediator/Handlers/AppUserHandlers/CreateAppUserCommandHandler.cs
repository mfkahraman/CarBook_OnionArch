using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler(IRepository<AppUser> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        IValidator<CreateAppUserCommand> validator)
        : IRequestHandler<CreateAppUserCommand, GetAppUserByIdQueryResult>
    {
        public async Task<GetAppUserByIdQueryResult> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            var entity = mapper.Map<AppUser>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetAppUserByIdQueryResult>(entity);
        }
    }
}