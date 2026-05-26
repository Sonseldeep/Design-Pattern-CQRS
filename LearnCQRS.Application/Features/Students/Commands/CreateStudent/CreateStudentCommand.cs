using ErrorOr;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Commands.CreateStudent;

public record CreateStudentCommand(
    string FirstName,
    string LastName,
    string Email) : IRequest<ErrorOr<Guid>>;
