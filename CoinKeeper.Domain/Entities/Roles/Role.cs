using Domain.Entities.Users;

namespace Domain.Entities.Roles;

public class Role
{
    public Role()
    {
        Users = new List<User>();
    }
    
    public string Id { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    
    public virtual ICollection<User> Users { get; set; }
}