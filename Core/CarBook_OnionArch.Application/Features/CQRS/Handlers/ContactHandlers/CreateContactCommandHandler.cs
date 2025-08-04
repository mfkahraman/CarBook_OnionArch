using AutoMapper;
using CarBook_OnionArch.Application.Features.CQRS.Commands.ContactCommands;
using CarBook_OnionArch.Application.Features.CQRS.Results.ContactResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;

namespace CarBook_OnionArch.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler(IRepository<Contact> repository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork)
    {
        public async Task<GetContactByIdQueryResult> Handle(CreateContactCommand command)
        {
            var entity = mapper.Map<Contact>(command);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Dbye kayıt işlemi sırasında bir hata oluştu");
            }

            return mapper.Map<GetContactByIdQueryResult>(entity);
        }
    }
}