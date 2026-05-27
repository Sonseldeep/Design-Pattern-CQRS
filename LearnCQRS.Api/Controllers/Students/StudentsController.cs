using MediatR;
using Microsoft.AspNetCore.Mvc;
using LearnCQRS.Api.Common;
using LearnCQRS.Application.Features.Students.Commands.CreateStudent;
using LearnCQRS.Application.Features.Students.Commands.UpdateStudent;
using LearnCQRS.Application.Features.Students.Commands.DeleteStudent;
using LearnCQRS.Application.Features.Students.Queries.GetAllStudents;
using LearnCQRS.Application.Features.Students.Queries.GetStudentById;

namespace LearnCQRS.Api.Controllers.Students;

[ApiController]
[Route("api/students")]
public class StudentsController : ApiController
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(
        [FromBody] CreateStudentCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match(
            id => CreatedAtAction(
                nameof(GetStudentById),
                new { id },
                ApiResponse<Guid>.SuccessResponse(
                    id,
                    "Student created successfully"
                )
            ),
            Problem
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllStudentsQuery(), cancellationToken);

        return result.Match(
            students => Ok(ApiResponse<object>.SuccessResponse(
                students,
                "Students retrieved successfully"
            )),
            Problem
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStudentById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetStudentByIdQuery(id), cancellationToken);

        return result.Match(
            student => Ok(ApiResponse<object>.SuccessResponse(
                student,
                "Student retrieved successfully"
            )),
            Problem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateStudent(
        Guid id,
        [FromBody] UpdateStudentCommand command,
        CancellationToken cancellationToken)
    {
        
        var commandWithId = command with { Id = id };

        var result = await _mediator.Send(commandWithId, cancellationToken);

        return result.Match(
            _ => Ok(ApiResponse<object>.SuccessResponseWithoutData(
                "Student updated successfully"
            )),
            Problem
        );
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteStudentCommand(id), cancellationToken);

        return result.Match(
            _ => NoContent(),
            Problem
        );
    }
}