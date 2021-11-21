using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Televizor.VolgaIronHack.Entities;
using Televizor.VolgaIronHack.Railway.Stations.Queries;
using Televizor.VolgaIronHack.Users;

namespace Televizor.VolgaIronHack.Railway.Stations;

public class StationController : AbstractController
{
    public StationController(
        VolgaIronHackDbContext dbContext,
        IMapper mapper,
        ILoggerFactory loggerFactory,
        ICurrentUserProvider currentUserProvider) : base(dbContext, mapper, loggerFactory, currentUserProvider) { }

    
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(IReadOnlyList<Station>), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchStations(
        StationSearchQuery query,
        CancellationToken cancellationToken)
    {
        var dbQuery = DbContext.Stations.AsQueryable();

        if (query.Text is not null or "")
            dbQuery = dbQuery.Where(station => station!.DisplayName.StartsWith(query.Text)
                                            || station.ExpressName.StartsWith(query.Text));

        var result = await dbQuery.ToListAsync(cancellationToken);

        return result.Count is 0
             ? NoContent()
             : Ok(result);
    }

    [HttpPost]
    [Obsolete]
    public async Task<IActionResult> Add(Station station)
    {
        await DbContext.AddAsync(station);
        await DbContext.SaveChangesAsync();

        return Ok();
    }
}