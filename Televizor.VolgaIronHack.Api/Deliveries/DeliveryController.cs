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
        throw new NotImplementedException();
    }

    [HttpDelete("id")]
    [Authorize(Roles = 
        $"{nameof(UserRole.TrainChief)}, " +
        $"{nameof(UserRole.Administrator)}, " +
        $"{nameof(UserRole.Client)}, " +
        $"{nameof(UserRole.Keeper)}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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
        var result = await DbContext.Parcels
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
            ? DbContext.Parcels.Where(d => d!.Request.InitiatorId == userId)
            : DbContext.Parcels;

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