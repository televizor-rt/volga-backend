namespace Televizor.VolgaIronHack;

public readonly struct GeoRange
{
    public GeoPoint Center { get; init; }
    
    public int RadiusInMeters { get; init; }
}