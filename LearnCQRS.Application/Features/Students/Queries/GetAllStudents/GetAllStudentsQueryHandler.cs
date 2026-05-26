using ErrorOr;
using LearnCQRS.Application.Features.Students.DTOs;
using LearnCQRS.Application.Features.Students.Mappings;
using LearnCQRS.Application.Features.Students.Repositories;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Queries.GetAllStudents;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, ErrorOr<List<StudentDto>>>
{
    private readonly IStudentRepository _studentRepository;

    public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<ErrorOr<List<StudentDto>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAllAsync(cancellationToken);
        var studentDto = students.Select(s => s.MapToDto());
        return studentDto.ToList();
    }
}