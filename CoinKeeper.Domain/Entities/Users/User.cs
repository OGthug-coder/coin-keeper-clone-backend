using Domain.Entities.Roles;

namespace Domain.Entities.Users;

public class User
{
    public User(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
        Roles = new List<Role>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string NormalizeName { get; set; } = null!;
    public string Email { get; set; }
    public string NormalizedEmail { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public bool EmailConfirmed { get; set; }
    
    public virtual ICollection<Role> Roles { get; set; }
}
