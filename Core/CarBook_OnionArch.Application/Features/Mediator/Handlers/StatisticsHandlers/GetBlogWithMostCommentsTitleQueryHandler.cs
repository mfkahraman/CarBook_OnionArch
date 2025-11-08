using CarBook_OnionArch.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook_OnionArch.Application.Features.Mediator.Results.StatisticsResults;
using CarBook_OnionArch.Application.Interfaces;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBlogWithMostCommentsTitleQueryHandler(IStatisticsRepository repository)
        : IRequestHandler<GetBlogWithMostCommentsTitleQuery, GetBlogWithMostCommentsTitleQueryResult>
    {
        public async Task<GetBlogWithMostCommentsTitleQueryResult> Handle(GetBlogWithMostCommentsTitleQuery request, CancellationToken cancellationToken)
        {
            var title = await repository.GetBlogWithMostCommentsTitleAsync(cancellationToken);
            return new GetBlogWithMostCommentsTitleQueryResult(title);
        }
    }
}
