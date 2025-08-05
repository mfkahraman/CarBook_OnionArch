using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.ServiceResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler(IRepository<Service> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateServiceCommand, GetServiceByIdQueryResult>
    {
        public async Task<GetServiceByIdQueryResult> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Service>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetServiceByIdQueryResult>(entity);
        }
    }
}