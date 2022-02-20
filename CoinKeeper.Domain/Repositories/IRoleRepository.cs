using Domain.Entities.Roles;
using Microsoft.AspNetCore.Identity;

namespace Domain.Repositories;

public interface IRoleRepository
{
    Task<Role> CreateAsync(Role role);
    
    Task<Role> UpdateAsync(Role role);

    Task<Role> DeleteAsync(Role role);

    Task<Role> FindByIdAsync(string roleId);

    Task<Role> FindByNameAsync(string normalizedRoleName);
}