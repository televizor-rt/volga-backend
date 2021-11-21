using Televizor.VolgaIronHack.Deliveries;

namespace Televizor.VolgaIronHack.Parcels.Queries;

public abstract class AbstractDeliverySetQuery
{
    public int Skip { get; set; }
    
    public int Take { get; set; }
    
    public bool OnlyMy { get; set; }
    
    public DeliveryDirection Direction { get; set; }
}
