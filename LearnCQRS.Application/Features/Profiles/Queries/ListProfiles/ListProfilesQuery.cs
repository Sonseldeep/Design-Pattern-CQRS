using ErrorOr;
using MediatR;

namespace LearnCQRS.Application.Features.Profiles.Queries.ListProfiles;

public record ListProfilesQuery(Guid UserId) : IRequest<ErrorOr<ListProfilesResult>>;