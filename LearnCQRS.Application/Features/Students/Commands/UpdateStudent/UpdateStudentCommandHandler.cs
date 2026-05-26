using ErrorOr;
using LearnCQRS.Application.Common.Interfaces;
using LearnCQRS.Application.Features.Students.Errors;
using LearnCQRS.Application.Features.Students.Repositories;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Commands.UpdateStudent;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, ErrorOr<Unit>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);
        if (student is null)
        {
            return StudentErrors.NotFound;
        }

        var emailExists = await _studentRepository.ExistsByEmailAsync(request.Email, cancellationToken);
        if (emailExists && student.Email != request.Email)
        {
            return StudentErrors.DuplicateEmail;
        }

        if (string.IsNullOrWhiteSpace(request.Email) ||
            string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName))
        {
            return StudentErrors.InValidData;
        }

        student.UpdateStudentDetails(
            request.FirstName,
            request.LastName,
            request.Email);

        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return Unit.Value;
    }
}