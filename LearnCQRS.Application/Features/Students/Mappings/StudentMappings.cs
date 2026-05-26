using LeanrCQRS.Domain.Students;
using LearnCQRS.Application.Features.Students.DTOs;

namespace LearnCQRS.Application.Features.Students.Mappings;

public static class StudentMappings
{
    public static StudentDto MapToDto(this Student student)
    {
        return new StudentDto(
            student.Id,
            student.FirstName,
            student.LastName,
            student.Email,
            student.Status.ToString()
        );
    }
}