using CoinKeeper.DataAccess.Database;
using Domain.Entities.Users;
using Domain.Repositories;
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
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        
        return user;
    }

    public async Task<User> DeleteAsync(User user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User> FindByIdAsync(string id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == id);
    }

    public async Task<User> FindByNameAsync(string normalizedName)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.NormalizeName == normalizedName);
    }


    public async Task<User> UpdateUserAsync(User user)
    {
        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return user;
    }
}