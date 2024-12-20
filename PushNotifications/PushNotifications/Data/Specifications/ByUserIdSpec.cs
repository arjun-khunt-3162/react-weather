using Ardalis.Specification;
using PushNotifications.Models;

namespace PushNotifications.Data.Specifications;

public class ByUserIdSpec : Specification<UserAndTokens>
{
    public ByUserIdSpec(string userId)
    {
        Query.Where(x => x.UserId == userId);
    }
}
