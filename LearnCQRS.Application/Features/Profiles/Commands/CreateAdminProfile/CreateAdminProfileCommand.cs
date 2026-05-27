using ErrorOr;
using MediatR;

namespace LearnCQRS.Application.Features.Profiles.Commands.CreateAdminProfile;

public record CreateAdminProfileCommand(Guid UserId)
    : IRequest<ErrorOr<Guid>>;