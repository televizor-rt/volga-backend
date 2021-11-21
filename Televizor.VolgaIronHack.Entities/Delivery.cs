namespace Televizor.VolgaIronHack.Entities;


public record Delivery
{
    public Guid Id { get; set; }
    
    public Guid RequestId { get; set; }
    
    public DeliveryRequest Request { get; set; }
    
    public Guid TrainTripId { get; set; }
    
    public TrainTrip Trip { get; set; }
    
    public Guid KeeperId { get; set; }
    
    public User Keeper { get; set; }
    
    public DeliveryStatus Status { get; set; }
    
    public IReadOnlyList<DeliveryStatusChange> StatusHistory { get; set; }
}