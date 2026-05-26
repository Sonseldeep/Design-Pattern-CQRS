namespace LearnCQRS.Application.Features.Students.DTOs;

public record StudentDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Status 
);

//// Enum as string