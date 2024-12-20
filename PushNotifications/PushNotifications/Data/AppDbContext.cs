using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PushNotifications.Models;

namespace PushNotifications.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<UserAndTokens> UserAndTokensSet { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
