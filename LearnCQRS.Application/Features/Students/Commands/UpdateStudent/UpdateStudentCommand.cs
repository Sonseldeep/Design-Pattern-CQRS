using ErrorOr;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Commands.UpdateStudent;

public record UpdateStudentCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email) : IRequest<ErrorOr<Unit>>
{
    public Guid Id { get; init; } = Guid.Empty;
}