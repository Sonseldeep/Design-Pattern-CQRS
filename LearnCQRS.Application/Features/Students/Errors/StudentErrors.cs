using ErrorOr;

namespace LearnCQRS.Application.Features.Students.Errors;

public class StudentErrors
{
    public static Error DuplicateEmail => 
        Error.Conflict(
            "Student.DuplicateEmail",
            "A student with that email address already exists.");

    public static Error InValidData =>
        Error.Validation(
            "Student.InvalidData",
            "Student data in invalid");
    
    public static Error NotFound =>
        Error.NotFound(
            "Student.NotFound",
            "Student not found");
}