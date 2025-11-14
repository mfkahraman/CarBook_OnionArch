using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.RentalCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.RentalResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.RentalHandlers
{
    public class CreateRentalCommandHandler(IRepository<Rental> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
        : IRequestHandler<CreateRentalCommand, GetRentalQueryResult>
    {
        public async Task<GetRentalQueryResult> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Rental>(request);
            var addResult = repository.Create(entity);
            if (!addResult)
            {
                throw new Exception("Add işlemi sırasında bir sorun oluştu.");
            }
            var commitResult = await unitOfWork.CommitAsync();
            if (!commitResult)
            {
                throw new Exception("Commit işlemi sırasında bir sorun oluştu.");
            }
            return mapper.Map<GetRentalQueryResult>(entity);
        }
    }
}
