using Microsoft.EntityFrameworkCore;

namespace PushNotifications.Data;

public static class AppDbContextExtensions
{
    public static void AddAppDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString)
        );
    }
}
