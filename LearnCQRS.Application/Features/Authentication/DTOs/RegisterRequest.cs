namespace LearnCQRS.Application.Features.Authentication.DTOs;


public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);