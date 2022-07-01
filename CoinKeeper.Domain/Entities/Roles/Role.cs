using Domain.Entities.Users;

namespace Domain.Entities.Roles;

public class Role
{
    public Role()
    {
        Users = new List<User>();
    }
    
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string NormalizedName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; }
}