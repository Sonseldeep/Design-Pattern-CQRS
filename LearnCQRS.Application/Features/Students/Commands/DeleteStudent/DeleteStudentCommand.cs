using ErrorOr;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Commands.DeleteStudent;

public record DeleteStudentCommand(Guid Id) : IRequest<ErrorOr<Unit>>;