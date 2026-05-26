using ErrorOr;
using LearnCQRS.Application.Common.Interfaces;
using LearnCQRS.Application.Features.Students.Errors;
using LearnCQRS.Application.Features.Students.Repositories;
using MediatR;

namespace LearnCQRS.Application.Features.Students.Commands.DeleteStudent;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, ErrorOr<Unit>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);
        if (student is null)
        {
            return StudentErrors.NotFound;
        }
        await _studentRepository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.CommitChangesAsync(cancellationToken);
        return Unit.Value;


    }
}