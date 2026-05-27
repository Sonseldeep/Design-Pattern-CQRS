
using LeanrCQRS.Domain.Users;

namespace LearnCQRS.Application.Features.Authentication.Common;


public record AuthenticationResult(
    User User,
    string Token);