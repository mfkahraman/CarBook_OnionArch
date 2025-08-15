using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
