using PushNotifications.Data;
using PushNotifications.Data.Specifications;
using PushNotifications.Models;

namespace PushNotifications;

public class UserAndTokensService(UserAndTokensRepository repository,
    ILogger<UserAndTokensService> logger)
{
    private readonly UserAndTokensRepository _repository = repository;
    private readonly ILogger<UserAndTokensService> _logger = logger;

    public Task<UserAndTokens> AddRecord(string fcmToken, string userId)
        => _repository.AddAsync(new(fcmToken, userId));

    public Task RemoveRecordByFcmToken(string fcmToken)
    {
        ByFcmTokenSpec spec = new(fcmToken);
        return _repository.DeleteRangeAsync(spec);
    }

    public Task RemoveRecordsByUserId(string userId)
    {
        ByUserIdSpec spec = new(userId);
        return _repository.DeleteRangeAsync(spec);
    }

    public Task<List<UserAndTokens>> GetFcmTokens(string userId)
    {
        ByUserIdSpec spec = new(userId);
        return _repository.ListAsync(spec);
    }

    public Task<List<UserAndTokens>> GetAllFcmTokens()
    {
        return _repository.ListAsync();
    }
}
