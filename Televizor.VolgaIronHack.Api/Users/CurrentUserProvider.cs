using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Televizor.VolgaIronHack.Entities;

namespace Televizor.VolgaIronHack.Users;

public class CurrentUserProvider : ICurrentUserProvider
{
    private readonly VolgaIronHackDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    
    public CurrentUserProvider(VolgaIronHackDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }


    public Task<User> GetCurrentUser(CancellationToken cancellationToken)
    {
        var sid = _httpContextAccessor.HttpContext?.User.Claims
            .SingleOrDefault(claim => claim.Type.Equals(ClaimTypes.Sid, StringComparison.Ordinal));

        return sid?.Value is null || !Guid.TryParse(sid.Value, out var uid)
            ? null
            : _dbContext.Users.SingleOrDefaultAsync(user => user.Id == uid, cancellationToken);
    }
}