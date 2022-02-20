using Domain.Entities.Roles;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace CoinKeeper.DataAccess.Infrastructure;

public class RoleStore : IRoleStore<Role>
{

    private readonly IRoleRepository _roleRepository;

    public RoleStore(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    
    public void Dispose()
    {
    }

    public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
    {
        await _roleRepository.CreateAsync(role);
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
    {
        await _roleRepository.UpdateAsync(role);
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
    {
        await _roleRepository.DeleteAsync(role);
        return IdentityResult.Success;
    }

    public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.Id);
    }

    public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.Name);
    }

    public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
    {
        role.Name = roleName;
        return Task.CompletedTask;
    }

    public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
    {
        return Task.FromResult(role.NormalizedName);
    }

    public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
    {
        role.NormalizedName = normalizedName;
        return Task.CompletedTask;
    }

    public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        return await _roleRepository.FindByIdAsync(roleId);
    }

    public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        return await _roleRepository.FindByNameAsync(normalizedRoleName);
    }
}