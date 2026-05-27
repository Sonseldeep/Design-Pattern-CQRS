using LearnCQRS.Application.Common.Models;

namespace LearnCQRS.Application.Common.Interfaces;

public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}