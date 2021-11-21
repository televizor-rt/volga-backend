namespace Televizor.VolgaIronHack.Entities;

public class Station
{
    public Guid Id { get; set; }
    
    public string ExpressId { get; set; }
    
    public string ExpressName { get; set; }
    
    public string DisplayName { get; set; }
    
    public decimal Latitude { get; set; }
    
    public decimal Longitude { get; set; }
    
    public string AdditionalData { get; set; }
}