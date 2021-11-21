namespace Televizor.VolgaIronHack.Entities;

public class DeliveryStatusChange
{
    public Guid Id { get; set; }
    
    public Guid DeliveryId { get; set; }
    
    public string Action { get; set; }
    
    public Guid? ActionCallerId { get; set; }
    
    public DeliveryStatus Status { get; set; }
    
    public DateTime Timestamp { get; set; }
}