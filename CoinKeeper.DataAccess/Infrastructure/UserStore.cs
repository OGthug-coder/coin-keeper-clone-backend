using Domain.Entities.Users;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace CoinKeeper.DataAccess.Infrastructure;

public class UserStore : IUserStore<User>, IUserPasswordStore<User>
{
    private readonly IUserRepository _userRepository;

    public UserStore(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public void Dispose()
    {
    }

    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Id.ToString());
    }

    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Name);
    }

    public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
        user.Name = userName;
    }

    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.NormalizeName);
    }

    public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
    {
        user.NormalizeName = normalizedName;
    }

    public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
        await _userRepository.CreateAsync(user);
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        await _userRepository.UpdateUserAsync(user);
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAsync(user);
        return IdentityResult.Success;
    }

    public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        return await _userRepository.FindByIdAsync(userId);
    }

    public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        return await _userRepository.FindByNameAsync(normalizedUserName);
    }

    public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash != null);
    }
}