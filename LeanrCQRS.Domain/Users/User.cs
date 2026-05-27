using ErrorOr;
using LeanrCQRS.Domain.Common;
using LeanrCQRS.Domain.Common.Interfaces;

namespace LeanrCQRS.Domain.Users;

public class User : Entity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    
    private readonly HashSet<Role> _roles = [];
    public IReadOnlyCollection<Role> Roles => _roles;
   
    private readonly string _passwordHash = null!;

    public User(
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        IEnumerable<Role>? roles = null,
        Guid? id = null)
            : base(id ?? Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        _passwordHash = passwordHash;
        if (roles is null) return;
        foreach (var role in roles)
            _roles.Add(role);
    }

    public void AddRole(Role role)
    {
        _roles.Add(role);
    }
    public void RemoveRole(Role role)
    {
        _roles.Remove(role);
    }

    public List<Role> GetRoles()
        => _roles.ToList();
    
    public bool IsCorrectPasswordHash(string password, IPasswordHasher passwordHasher)
    {
        return passwordHasher.IsCorrectPassword(password, _passwordHash);
    }
    private User() { }
}