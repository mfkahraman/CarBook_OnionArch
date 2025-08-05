using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.LocationCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.LocationResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.LocationHandlers
{
    internal class CreateLocationCommandHandler(IRepository<Location> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateLocationCommand, GetLocationByIdQueryResult>
    {
        public async Task<GetLocationByIdQueryResult> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Location>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetLocationByIdQueryResult>(entity);
        }
    }
}