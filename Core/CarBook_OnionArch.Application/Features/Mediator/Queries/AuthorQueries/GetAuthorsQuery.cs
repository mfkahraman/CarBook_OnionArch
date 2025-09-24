using CarBook_OnionArch.Application.Features.Mediator.Results.AuthorResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorsQueryResult>>;
}
