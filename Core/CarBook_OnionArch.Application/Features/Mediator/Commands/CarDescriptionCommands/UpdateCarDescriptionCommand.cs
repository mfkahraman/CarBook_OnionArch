using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class UpdateCarDescriptionCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public required string Detail { get; set; }
        public int CarId { get; set; }
    }
}
