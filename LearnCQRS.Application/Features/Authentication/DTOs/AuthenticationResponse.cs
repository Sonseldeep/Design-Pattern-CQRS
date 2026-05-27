namespace LearnCQRS.Application.Features.Authentication.DTOs;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);