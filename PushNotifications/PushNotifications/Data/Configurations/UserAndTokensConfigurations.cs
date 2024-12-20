using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PushNotifications.Models;

namespace PushNotifications.Data.Configurations;

public class UserAndTokensConfigurations : IEntityTypeConfiguration<UserAndTokens>
{
    public void Configure(EntityTypeBuilder<UserAndTokens> builder)
    {
        builder.ToTable("UserAndTokens");

        builder.HasKey(x => x.FcmToken);
        builder.Property(x => x.FcmToken).HasMaxLength(500);

        builder.Property(x => x.UserId).HasMaxLength(100);
    }
}
