using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Televizor.VolgaIronHack.Deliveries.Commands;
using Televizor.VolgaIronHack.Deliveries.Queries;
using Televizor.VolgaIronHack.Deliveries.Views;
using Televizor.VolgaIronHack.Entities;
using Televizor.VolgaIronHack.Parcels.Queries;
using Televizor.VolgaIronHack.Users;

namespace Televizor.VolgaIronHack.Deliveries;

public class DeliveryController : AbstractController
{
    public DeliveryController(
        VolgaIronHackDbContext dbContext,
        IMapper mapper,
        ILoggerFactory loggerFactory,
        ICurrentUserProvider currentUserProvider)
        : base(dbContext, mapper, loggerFactory, currentUserProvider) { }


    [HttpPost]
    [ValidateModel]
    [Authorize(Roles = $"{nameof(UserRole.TrainChief)}, {nameof(UserRole.Administrator)}")]
    public async Task<IActionResult> Create(DeliveryCreateCommand command, CancellationToken cancellationToken)
    {
        var request = await DbContext.TrainTrips
            .SingleOrDefaultAsync(r => r!.Id == command.DeliveryRequestId, cancellationToken);
        if (request is null)
        {
            Logger.LogWarning(
                "Couldn't find delivery request for {Command}: {ID}}",
                nameof(DeliveryCreateCommand),
                command.DeliveryRequestId);
            return BadRequest();
        }
        
        var trip = await DbContext.TrainTrips
            .SingleOrDefaultAsync(t => t!.Id == command.TrainTripId, cancellationToken);
        if (trip is null)
        {
            Logger.LogWarning(
                "Couldn't find trip for {Command}: {ID}}", nameof(DeliveryCreateCommand), command.TrainTripId);
            return BadRequest();
        }

        // TODO: Check that keeper is on this train

        var delivery = Mapper.Map<Delivery>(command);

        delivery.Id = Guid.NewGuid();
        delivery.Status = DeliveryStatus.Opened;

        await DbContext.AddAsync(delivery, cancellationToken);
        await DbContext.AddAsync(new DeliveryStatusChange
        {
            Action = nameof(DeliveryCreateCommand),
            ActionCallerId = (await CurrentUserProvider.GetCurrentUser(cancellationToken)).Id,
            DeliveryId = delivery.Id,
            Id = Guid.NewGuid(),
            Status = delivery.Status,
            Timestamp = DateTime.UtcNow
        }, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
        
        return CreatedAtAction(nameof(GetSingle), new {id = delivery.Id});
    }

    [HttpDelete("id")]
    [Authorize(Roles = 
        $"{nameof(UserRole.TrainChief)}, " +
        $"{nameof(UserRole.Administrator)}, " +
        $"{nameof(UserRole.Client)}, " +
        $"{nameof(UserRole.Keeper)}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var target = await DbContext.Deliveries.SingleOrDefaultAsync(d => d!.Id == id, cancellationToken);
        if (target is null)
            return NotFound();

        var user = await CurrentUserProvider.GetCurrentUser(cancellationToken);

        switch (target.Status)
        {
            case DeliveryStatus.Opened:
                throw new NotImplementedException();
            case DeliveryStatus.FirstMile:
                throw new NotImplementedException();
            case DeliveryStatus.EnRoute:
                throw new NotImplementedException();
            case DeliveryStatus.LastMile:
            case DeliveryStatus.Delivered:
            case DeliveryStatus.Closed:
            default:
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
        }
    }

    [HttpGet("id")]
    [ProducesResponseType(typeof(Delivery), StatusCodes.Status200OK)]
    [Authorize(Roles = 
        $"{nameof(UserRole.TrainChief)}, " +
        $"{nameof(UserRole.Administrator)}, " +
        $"{nameof(UserRole.Client)}, " +
        $"{nameof(UserRole.Keeper)}")]
    public async Task<IActionResult> GetSingle(Guid id, CancellationToken cancellationToken)
    {
        var result = await DbContext.Deliveries
            .SingleOrDefaultAsync(d => d.Id == id, cancellationToken);

        return result == null ? NotFound() : Ok(result);
    }
    
    [HttpGet("my/map")]
    [Authorize] // Client
    [ValidateModel]
    [ProducesResponseType(typeof(IReadOnlyList<DeliverySetViewItem>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserDeliveriesMapView(
        DeliveryMapQuery query, CancellationToken cancellationToken)
    {
        var (uid, _, _, _) = await CurrentUserProvider.GetCurrentUser(cancellationToken);

        var dbQuery = Query(uid, query)
            .Where(d => d.Request.SenderId == uid || d.Request.ReceiverId == uid)
            .Where(d => d.Status == DeliveryStatus.EnRoute || d.Status == DeliveryStatus.LastMile);
        
        return GetListResult(new ListView<DeliverySetViewItem>(
            await dbQuery
                .ProjectTo<DeliverySetViewItem>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)));
    }
    
    [HttpGet("my")]
    [Authorize] // Client
    [ProducesResponseType(typeof(IReadOnlyList<DeliverySetViewItem>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserDeliveriesListView(DeliveryListQuery query, CancellationToken cancellationToken)
    {
        var user = await CurrentUserProvider.GetCurrentUser(cancellationToken);
        var dbQuery = Query(user.Id, query);

        if (query.Statuses.Count is not 0)
            dbQuery = dbQuery.Where(d => query.Statuses.Contains(d.Status));

        var result = await dbQuery
            .ProjectTo<DeliverySetViewItem>(Mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return GetListResult(new ListView<DeliverySetViewItem>(result));
    }


    private IQueryable<Delivery?> Query(Guid userId, AbstractDeliverySetQuery query)
    {
        var dbQuery = query.OnlyMy
            ? DbContext.Deliveries.Where(d => d!.Request.InitiatorId == userId)
            : DbContext.Deliveries;

        dbQuery = query.Direction switch
        {
            DeliveryDirection.Input => dbQuery.Where(d => d!.Request.ReceiverId == userId),
            DeliveryDirection.Output => dbQuery.Where(d => d!.Request.SenderId == userId),
            DeliveryDirection.Both => dbQuery.Where(d => d!.Request.ReceiverId == userId || d.Request.SenderId == userId),
            _ => throw new ArgumentOutOfRangeException()
        };

        return dbQuery;
    }
}