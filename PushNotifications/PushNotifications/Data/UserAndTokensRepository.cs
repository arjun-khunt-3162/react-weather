using Ardalis.Specification.EntityFrameworkCore;
using PushNotifications.Models;

namespace PushNotifications.Data;

public class UserAndTokensRepository(AppDbContext dbContext) : 
    RepositoryBase<UserAndTokens>(dbContext)
{
}
