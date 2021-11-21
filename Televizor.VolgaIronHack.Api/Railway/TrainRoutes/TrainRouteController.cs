using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Televizor.VolgaIronHack.Entities;
using Televizor.VolgaIronHack.Users;

namespace Televizor.VolgaIronHack.Railway.TrainRoutes;

public class TrainRouteController : AbstractController
{
    public TrainRouteController(
        VolgaIronHackDbContext dbContext,
        IMapper mapper,
        ILoggerFactory loggerFactory,
        ICurrentUserProvider currentUserProvider) : base(dbContext, mapper, loggerFactory, currentUserProvider) { }


    [HttpPost]
    [Obsolete]
    public async Task<IActionResult> Add(TrainRoute route)
    {
        await DbContext.AddAsync(route);
        await DbContext.AddRangeAsync(route.Stops);
        await DbContext.SaveChangesAsync();

        return Ok();
    }
}