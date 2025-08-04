using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.ContactCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler(IRepository<Contact> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<bool> Handle(UpdateContactCommand command)
        {
            var entity = mapper.Map<Contact>(command);
            repository.Update(entity);
            return await unitOfWork.CommitAsync();
        }
    }
}
