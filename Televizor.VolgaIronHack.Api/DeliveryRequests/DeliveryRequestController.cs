using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Televizor.VolgaIronHack.Entities;
using Televizor.VolgaIronHack.Users;

namespace Televizor.VolgaIronHack.DeliveryRequests;

public class DeliveryRequestController : AbstractController
{
    public DeliveryRequestController(
        VolgaIronHackDbContext dbContext,
        IMapper mapper,
        ILoggerFactory loggerFactory,
        ICurrentUserProvider currentUserProvider) : base(dbContext, mapper, loggerFactory, currentUserProvider) { }


    [HttpPost]
    [Authorize]
    [ValidateModel]
    public async Task<IActionResult> CreateDeliveryRequest(
        CreateDeliveryRequestCommand command, CancellationToken cancellationToken)
    {
        var request = Mapper.Map<DeliveryRequest>(command);

        request.Id = Guid.NewGuid();

        await DbContext.AddAsync(request, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return CreatedAtAction(nameof(GetSingle), new{id = request.Id});
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetSingle(Guid id, CancellationToken cancellationToken)
    {
        var result = await DbContext.DeliveryRequests
            .SingleOrDefaultAsync(request => request!.Id == id, cancellationToken);

        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Discard(Guid id, CancellationToken cancellationToken)
    {
        var target = await DbContext.DeliveryRequests
            .SingleOrDefaultAsync(request => request!.Id == id, cancellationToken);

        if (target is null)
            return NotFound();

        DbContext.Remove(target);

        await DbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }
}