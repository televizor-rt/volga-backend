namespace Televizor.VolgaIronHack.Entities;

public class TrainTrip
{
    public Guid Id { get; set; }
    
    public Guid ChiefId { get; set; }
    
    public Guid TrainRouteId { get; set; }
    
    public TrainRoute Route { get; set; }
    
    
}