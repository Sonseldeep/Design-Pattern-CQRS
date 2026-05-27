using LeanrCQRS.Domain.Users;

namespace LearnCQRS.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}