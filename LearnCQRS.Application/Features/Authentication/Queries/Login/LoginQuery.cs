using ErrorOr;
using LearnCQRS.Application.Features.Authentication.Common;
using MediatR;

namespace LearnCQRS.Application.Features.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;