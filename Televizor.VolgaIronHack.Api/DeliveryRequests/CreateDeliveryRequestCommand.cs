using Televizor.VolgaIronHack.Entities;

namespace Televizor.VolgaIronHack.DeliveryRequests;

public class CreateDeliveryRequestCommand
{
    public DateTime? ExpirationTime { get; set; }
    
    public decimal Value { get; set; }
    
    public decimal Weight { get; set; }
    
    public ParcelSize Size { get; set; }
}