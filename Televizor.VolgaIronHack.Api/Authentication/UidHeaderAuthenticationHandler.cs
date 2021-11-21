using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Televizor.VolgaIronHack.Entities;


namespace Televizor.VolgaIronHack.Authentication;

public class UidHeaderAuthenticationHandler<TUser> : AuthenticationHandler<UidParameterAuthenticationOptions>
    where TUser : class
{
    private readonly VolgaIronHackDbContext _dbContext;
    
    public UidHeaderAuthenticationHandler(
        IOptionsMonitor<UidParameterAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        VolgaIronHackDbContext dbContext)
        : base(options, logger, encoder, clock)
        => _dbContext = dbContext;


    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string? requestValue = Options.ParameterSource switch
        {
            UidParameterSource.Header => Context.Request.Headers[Options.ParameterName],
            UidParameterSource.Cookie => Context.Request.Cookies[Options.ParameterName],
            UidParameterSource.Query => Context.Request.Query[Options.ParameterName],
            _ => throw new ArgumentOutOfRangeException()
        };

        if (!Guid.TryParse(requestValue, out var id))
            return AuthenticateResult.NoResult();

        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return AuthenticateResult.NoResult();

        Context.Features.Set(user);
        
        var claims = new[]
        {
            new Claim(ClaimTypes.Sid, requestValue),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

        return AuthenticateResult.Success(
            new AuthenticationTicket(
                new ClaimsPrincipal(
                    new ClaimsIdentity(claims)
                ),
                UidHeaderAuthentication.Scheme
            )
        );
    }
}