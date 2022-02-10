namespace Domain.Entities.Users;

public class User
{
    public User(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string NormalizeName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}