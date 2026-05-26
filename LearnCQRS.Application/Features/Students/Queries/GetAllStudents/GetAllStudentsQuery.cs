using ErrorOr;
using LearnCQRS.Application.Features.Students.DTOs;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Queries.GetAllStudents;

public record GetAllStudentsQuery : IRequest<ErrorOr<List<StudentDto>>>;