using Televizor.VolgaIronHack.Entities;

namespace Televizor.VolgaIronHack.Deliveries.Views;

public class DeliverySetViewItem
{
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public string InitiatorName { get; }
    
    public string SenderName { get; set; }
    
    public string ReceiverName { get; set; }
    
    public string TrainChiefName { get; set; } 
    
    public string KeeperName { get; set; }

    public Guid SoureStationId { get; set; }
    
    public Guid DestinationStationId { get; set; }
    
    public Guid TrainRouteId { get; set; }
    
    public DeliveryStatus Status { get; set; }
    
    public decimal Latitude { get; set; }
    
    public decimal Longitude { get; set; }
}