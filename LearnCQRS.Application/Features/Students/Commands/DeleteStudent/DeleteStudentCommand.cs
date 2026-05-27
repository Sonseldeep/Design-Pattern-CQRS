using ErrorOr;
using LearnCQRS.Application.Common.Authorization;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Commands.DeleteStudent;

[Authorize(Roles = "Admin")]


public record DeleteStudentCommand(Guid Id) : IRequest<ErrorOr<Unit>>;