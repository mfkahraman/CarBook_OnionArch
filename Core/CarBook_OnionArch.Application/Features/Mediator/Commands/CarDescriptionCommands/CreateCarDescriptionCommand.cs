using CarBook_OnionArch.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class CreateCarDescriptionCommand : IRequest<GetCarDescriptionByIdQueryResult>
    {
        public required string Detail { get; set; }
        public int CarId { get; set; }
    }
}
