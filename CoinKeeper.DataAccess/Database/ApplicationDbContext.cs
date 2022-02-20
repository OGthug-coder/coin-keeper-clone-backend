using CoinKeeper.DataAccess.Database.Maps;
using Domain.Entities.Roles;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CoinKeeper.DataAccess.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new RoleMap());
        
        base.OnModelCreating(modelBuilder);
    }
}