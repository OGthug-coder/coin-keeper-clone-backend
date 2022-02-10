using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);

    Task<User> DeleteAsync(User user);

    Task<User> FindByIdAsync(string id);

    Task<User> FindByNameAsync(string name);

    Task<User> UpdateUserAsync(User user);
}