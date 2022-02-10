using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CoinKeeper.DataAccess.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
}