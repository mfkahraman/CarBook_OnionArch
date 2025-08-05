using AutoMapper;
using CarBook_OnionArch.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook_OnionArch.Application.Features.Mediator.Results.FooterAddressResults;
using CarBook_OnionArch.Application.Interfaces;
using CarBook_OnionArch.Domain.Entities;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        : IRequestHandler<CreateFooterAddressCommand, GetFooterAddressByIdQueryResult>
    {
        public async Task<GetFooterAddressByIdQueryResult> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<FooterAddress>(request);
            repository.Create(entity);
            var result = await unitOfWork.CommitAsync();

            if (!result)
            {
                throw new Exception("Db'ye kayıt işlemi sırasında bir sorun oluştu.");
            }

            return mapper.Map<GetFooterAddressByIdQueryResult>(entity);
        }
    }
}