namespace Televizor.VolgaIronHack.Entities;

public class DeliveryRequest
{
    public Guid Id { get; set; }
    
    public Guid InitiatorId { get; set; }
    
    public Guid SenderId { get; set; }
    
    public Guid ReceiverId { get; set; }
    
    public DateTime CreatedTime { get; set; }
    
    public DateTime? ExpirationTime { get; set; }
    
    public decimal Value { get; set; }
    
    public decimal Weight { get; set; }
    
    public ParcelSize Size { get; set; }
    
    public Guid? DeliveryId { get; set; }
    
    public Guid SourceStationId { get; set; }
    
    public Station SourceStation { get; set; }
    
    public Guid DestinationStationId { get; set; }
    
    public Station DestinationStation { get; set; }
}