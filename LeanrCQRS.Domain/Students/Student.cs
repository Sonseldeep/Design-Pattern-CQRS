namespace LeanrCQRS.Domain.Students;

public class Student
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }         
    public StudentStatus Status { get; private set; }

    private Student(Guid id, string firstName, string lastName, string email, StudentStatus status)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Status = status;
    }

    private Student() { }

    public static Student? Create(string firstName, string lastName, string email, StudentStatus status)
    {
        if (string.IsNullOrWhiteSpace(email))
            return null;

        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            return null;

        return new Student(Guid.NewGuid(), firstName, lastName, email, status);
    }

    public void UpdateStatus(StudentStatus newStatus) => Status = newStatus;
    public void UpdateStudentDetails(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}