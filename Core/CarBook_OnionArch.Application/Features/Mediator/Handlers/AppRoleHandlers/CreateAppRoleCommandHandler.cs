using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.AppRoleCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.AppRoleResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.AppRoleHandlers
{
    public class CreateAppRoleCommandHandler(IAppRoleRepository repository,
                                            IMapper mapper)
        : IRequestHandler<CreateAppRoleCommand, GetAppRoleByIdQueryResult>
    {
        public async Task<GetAppRoleByIdQueryResult> Handle(CreateAppRoleCommand request, CancellationToken cancellationToken)
        {
            var AppRoleEntity = mapper.Map<AppRole>(request);

            var result = await repository.CreateRoleAsync(AppRoleEntity);

            if (!result.Succeeded)
            {
                throw new Exception("Role creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return mapper.Map<GetAppRoleByIdQueryResult>(AppRoleEntity);
        }
    }
}