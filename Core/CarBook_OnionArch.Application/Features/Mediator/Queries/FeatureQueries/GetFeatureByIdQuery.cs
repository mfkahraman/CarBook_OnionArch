﻿using CarBook_OnionArch.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace CarBook_OnionArch.Application.Features.Mediator.Queries.FeatureQueries
{
    public record GetFeatureByIdQuery(int Id) : IRequest<GetFeatureByIdQueryResult>;
}
