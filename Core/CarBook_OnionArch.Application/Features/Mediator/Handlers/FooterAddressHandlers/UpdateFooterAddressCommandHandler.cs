using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    internal class UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateFooterAddressCommand, bool>
    {
        public async Task<bool> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<FooterAddress>(request);
            repository.Update(entity);
            var result = await unitOfWork.CommitAsync();
            if (!result)
            {
                throw new Exception("Db güncelleme işlemi sırasında bir sorun oluştu.");
            }
            return true;
        }
    }
}
