using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class UpdateAppUserCommandHandler(IRepository<AppUser> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        IValidator<UpdateAppUserCommand> validator)
        : IRequestHandler<UpdateAppUserCommand, bool>
    {
        public async Task<bool> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var validationResul = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResul.IsValid)
            {
                throw new ValidationException(validationResul.Errors);
            }

            var entity = mapper.Map<AppUser>(request);
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