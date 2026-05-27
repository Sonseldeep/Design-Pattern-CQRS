using ErrorOr;
using LearnCQRS.Application.Features.Authentication.Common;
using MediatR;

namespace LearnCQRS.Application.Features.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;