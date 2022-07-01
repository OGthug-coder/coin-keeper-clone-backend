using CoinKeeper.DataAccess.Database;
using Domain.Entities.Roles;
using Domain.Entities.Users;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoinKeeper.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        _dbContext.Users!.Add(user);
        await _dbContext.SaveChangesAsync();
        
        return user;
    }

    public async Task<User> DeleteAsync(User user)
    {
        _dbContext.Users!.Remove(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> FindByIdAsync(string id)
    {
        return (await _dbContext.Users!.FirstOrDefaultAsync(x => x.Id.ToString() == id))!;
    }

    public async Task<User> FindByNameAsync(string normalizedName)
    {
        return (await _dbContext.Users!.FirstOrDefaultAsync(x => x.NormalizeName == normalizedName))!;
    }


    public async Task<User> UpdateUserAsync(User user)
    {
        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> FindByEmailAsync(string normalizedEmail)
    {
        return (await _dbContext.Users!.FirstOrDefaultAsync(x => x.NormalizedEmail == normalizedEmail))!;
    }

    public async Task<User> AddRoleAsync(User user, Role role)
    {
        user.Roles.Add(role);
        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> RemoveRoleAsync(User user, Role role)
    {
        user.Roles.Remove(role);
        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName)
    {
        return Task.FromResult<IEnumerable<User>>(_dbContext.Users!.Where(x => x.Roles.Any(y => y.NormalizedName == roleName)));
    }
}