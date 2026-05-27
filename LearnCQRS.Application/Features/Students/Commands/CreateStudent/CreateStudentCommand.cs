using ErrorOr;
using LearnCQRS.Application.Common.Authorization;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Commands.CreateStudent;

[Authorize(Roles = $"{LeanrCQRS.Domain.Common.Roles.Admin},{LeanrCQRS.Domain.Common.Roles.TrustedMember}")]
public record CreateStudentCommand(
    string FirstName,
    string LastName,
    string Email) : IRequest<ErrorOr<Guid>>;
