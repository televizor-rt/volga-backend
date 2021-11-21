namespace Televizor.VolgaIronHack.Entities;

public class TrainRoute
{
    public Guid Id { get; set; }
    
    public string ExpressId { get; set; }
    
    public IReadOnlyList<TrainRouteStop> Stops { get; set; }
}