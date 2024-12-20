using Ardalis.Specification;
using PushNotifications.Models;

namespace PushNotifications.Data.Specifications;

public class ByFcmTokenSpec: Specification<UserAndTokens>
{
    public ByFcmTokenSpec(string fcmToken)
    {
        Query.Where(x => x.FcmToken == fcmToken);
    }
}
