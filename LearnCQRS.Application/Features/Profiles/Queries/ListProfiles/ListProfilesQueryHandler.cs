using ErrorOr;
using LearnCQRS.Application.Common.Interfaces;
using MediatR;

namespace LearnCQRS.Application.Features.Profiles.Queries.ListProfiles;

public class ListProfilesQueryHandler : IRequestHandler<ListProfilesQuery, ErrorOr<ListProfilesResult>>
{
    private readonly IUsersRepository _usersRepository;
    private readonly ICurrentUserProvider _currentUserProvider;

    public ListProfilesQueryHandler(IUsersRepository usersRepository, ICurrentUserProvider currentUserProvider)
    {
        _usersRepository = usersRepository;
        _currentUserProvider = currentUserProvider;
    }

    public async Task<ErrorOr<ListProfilesResult>> Handle(ListProfilesQuery query, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserProvider.GetCurrentUser();

        // Allow only Admins or the user themself to see profile IDs
        if (!currentUser.Roles.Contains("Admin") && currentUser.Id != query.UserId)
        {
            return Error.Unauthorized(description: "Forbidden");
        }

        var user = await _usersRepository.GetByIdAsync(query.UserId);
        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return new ListProfilesResult(user.AdminId, user.ParticipantId, user.TrainerId);
    }
}