using Televizor.VolgaIronHack.Entities;

namespace Televizor.VolgaIronHack.Users;

public interface ICurrentUserProvider
{
    Task<User> GetCurrentUser(CancellationToken cancellationToken);
}