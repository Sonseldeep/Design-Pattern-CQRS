using ErrorOr;
using LearnCQRS.Application.Features.Students.DTOs;
using LearnCQRS.Application.Features.Students.Errors;
using LearnCQRS.Application.Features.Students.Mappings;
using LearnCQRS.Application.Features.Students.Repositories;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Queries.GetStudentById;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, ErrorOr<StudentDto>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<ErrorOr<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);
        if (student is null)
        {
            return StudentErrors.NotFound;
        }
        return student.MapToDto();
    }
}