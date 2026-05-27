using ErrorOr;
using LearnCQRS.Application.Common.Authorization;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Commands.UpdateStudent;

[Authorize(Roles = LeanrCQRS.Domain.Common.Roles.Admin)]

public record UpdateStudentCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email) : IRequest<ErrorOr<Unit>>
{
    public Guid Id { get; init; } = Guid.Empty;
}