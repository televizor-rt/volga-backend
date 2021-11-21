namespace Televizor.VolgaIronHack.Deliveries.Commands;

public class DeliveryCreateCommand
{
    public Guid DeliveryRequestId { get; set; }
    
    public Guid TrainTripId { get; set; }
    
    public Guid KeeperId { get; set; }
}