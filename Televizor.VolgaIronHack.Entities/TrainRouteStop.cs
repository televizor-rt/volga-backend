namespace Televizor.VolgaIronHack.Entities;

public class TrainRouteStop
{
    public Guid Id { get; set; }
    
    public Guid TrainRouteId { get; set; }
    
    public DateTime? MoscowArriveTime { get; set; }
    
    public DateTime? MoscowDepartureTime { get; set; }
    
    public int? StopTimeInMinutes { get; set; }
}