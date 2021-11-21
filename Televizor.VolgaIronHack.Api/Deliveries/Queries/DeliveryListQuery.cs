using Televizor.VolgaIronHack.Entities;
using Televizor.VolgaIronHack.Parcels.Queries;

namespace Televizor.VolgaIronHack.Deliveries.Queries;

public class DeliveryListQuery : AbstractDeliverySetQuery
{
    public IReadOnlyList<DeliveryStatus> Statuses { get; set; }
}