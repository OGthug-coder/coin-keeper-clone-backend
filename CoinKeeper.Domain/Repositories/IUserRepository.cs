using Domain.Entities.Roles;
using Domain.Entities.Users;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);

    Task<User> DeleteAsync(User user);

    Task<User> FindByIdAsync(string id);

    Task<User> FindByNameAsync(string normalizedName);

    Task<User> UpdateUserAsync(User user);

    Task<User> FindByEmailAsync(string normalizedEmail);

    Task<User> AddRoleAsync(User user, Role role);

    Task<User> RemoveRoleAsync(User user, Role role);

    Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName);
}