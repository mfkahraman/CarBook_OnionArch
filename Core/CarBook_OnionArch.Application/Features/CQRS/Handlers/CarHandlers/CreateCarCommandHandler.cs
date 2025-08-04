using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.CarCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.CarResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler(IRepository<Car> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<GetCarByIdQueryResult> Handle(CreateCarCommand command)
        {
            var entity = mapper.Map<Car>(command);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Dbye kayıt işlemi sırasında bir hata oluştu");
            }

            return mapper.Map<GetCarByIdQueryResult>(entity);
        }
    }
}
