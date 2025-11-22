using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler(IAppUserRepository repository,
                                        IMapper mapper,
                                        IValidator<CreateAppUserCommand> validator)
        : IRequestHandler<CreateAppUserCommand, GetAppUserByIdQueryResult>
    {
        public async Task<GetAppUserByIdQueryResult> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var appUserEntity = mapper.Map<AppUser>(request);

            var result = await repository.CreateUserAsync(appUserEntity, appUserEntity.PasswordHash!);

            if(!result.Succeeded)
            {
                throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var createdUser = await repository.FindUserByUserNameAsync(appUserEntity.UserName!);
            return mapper.Map<GetAppUserByIdQueryResult>(createdUser);
        }
    }
}