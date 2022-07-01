using CoinKeeper.DataAccess.Database;
using Domain.Entities.Roles;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoinKeeper.DataAccess.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RoleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Role> CreateAsync(Role role)
    {
        _dbContext.Roles!.Add(role);
        await _dbContext.SaveChangesAsync();
        return role;
    }

    public async Task<Role> UpdateAsync(Role role)
    {
        _dbContext.Entry(role).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return role;
    }

    public async Task<Role> DeleteAsync(Role role)
    {
        _dbContext.Roles!.Remove(role);
        await _dbContext.SaveChangesAsync();

        return role;
    }

    public async Task<Role> FindByIdAsync(string roleId)
    {
        return (await _dbContext.Roles!.FirstOrDefaultAsync(x => x.Id == roleId))!;
    }

    public async Task<Role> FindByNameAsync(string normalizedRoleName)
    {
        return (await _dbContext.Roles!.FirstOrDefaultAsync(x => x.NormalizedName == normalizedRoleName))!;
    }
}