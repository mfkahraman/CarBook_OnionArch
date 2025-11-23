using CarBook_OnionArch.Application.Features.Mediator.Results.UserResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.AppUserCommands
{
    public class CreateAppUserCommand : IRequest<GetAppUserByIdQueryResult>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? ImagePath { get; set; }
    }
}
