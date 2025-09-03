using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.CarDescriptionCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class CreateCarDescriptionCommandHandler(IRepository<CarDescription> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateCarDescriptionCommand, GetCarDescriptionByIdQueryResult>
    {
        public async Task<GetCarDescriptionByIdQueryResult> Handle(CreateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CarDescription>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetCarDescriptionByIdQueryResult>(entity);
        }
    }
}