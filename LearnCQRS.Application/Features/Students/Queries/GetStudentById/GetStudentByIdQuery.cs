using ErrorOr;
using LearnCQRS.Application.Features.Students.DTOs;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Queries.GetStudentById;

public record GetStudentByIdQuery(Guid Id): IRequest<ErrorOr<StudentDto>>;
