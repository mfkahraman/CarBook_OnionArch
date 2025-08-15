using CarBook_OnionArch.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureCommand : IRequest<GetCarFeatureQueryResult>
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
