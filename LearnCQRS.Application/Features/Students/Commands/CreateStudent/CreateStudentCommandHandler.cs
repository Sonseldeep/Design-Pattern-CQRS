using ErrorOr;
using LeanrCQRS.Domain.Students;
using LearnCQRS.Application.Common.Interfaces;
using LearnCQRS.Application.Features.Students.Errors;
using LearnCQRS.Application.Features.Students.Repositories;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, ErrorOr<Guid>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Guid>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        if (await _studentRepository.ExistsByEmailAsync(request.Email, cancellationToken))
        {
            return StudentErrors.DuplicateEmail;
        }
        
        var student = Student.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            StudentStatus.Active);
        
        if (student is null)
        {
            return StudentErrors.InValidData;
        }
        
        await _studentRepository.AddAsync(student, cancellationToken);
        await _unitOfWork.CommitChangesAsync(cancellationToken);
        return student.Id;
    }
}