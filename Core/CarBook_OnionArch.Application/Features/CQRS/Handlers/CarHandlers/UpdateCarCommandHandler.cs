using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.CarCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler(IRepository<Car> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(UpdateCarCommand command)
        {
            var entity = mapper.Map<Car>(command);
            repository.Update(entity);
            return await unitOfWork.CommitAsync();
        }
    }
}
