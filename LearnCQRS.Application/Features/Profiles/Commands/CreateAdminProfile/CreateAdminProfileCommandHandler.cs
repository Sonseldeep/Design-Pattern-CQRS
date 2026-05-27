using ErrorOr;
using LearnCQRS.Application.Common.Interfaces;
using MediatR;

namespace LearnCQRS.Application.Features.Profiles.Commands.CreateAdminProfile;

public class CreateAdminProfileCommandHandler : IRequestHandler<CreateAdminProfileCommand, ErrorOr<Guid>>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserProvider _currentUserProvider;

    public CreateAdminProfileCommandHandler(
        IUsersRepository usersRepository,
        IUnitOfWork unitOfWork,
        ICurrentUserProvider currentUserProvider)
    {
        _usersRepository = usersRepository;
        _unitOfWork = unitOfWork;
        _currentUserProvider = currentUserProvider;
    }

    public async Task<ErrorOr<Guid>> Handle(CreateAdminProfileCommand command, CancellationToken cancellationToken)
    {
        var currentUser = _currentUserProvider.GetCurrentUser();

        // Only Admins are allowed to assign the Admin profile to a user
        if (!currentUser.Roles.Contains("Admin"))
        {
            return Error.Unauthorized(description: "Only admins can assign admin profiles.");
        }

        var user = await _usersRepository.GetByIdAsync(command.UserId);
        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        var createAdminProfileResult = user.CreateAdminProfile();

        await _usersRepository.UpdateAsync(user);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return createAdminProfileResult;
    }
}