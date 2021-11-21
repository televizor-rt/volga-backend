namespace Televizor.VolgaIronHack.Railway.Stations.Queries;

public class StationSearchQuery
{
    public string Text { get; set; }
    
    public GeoRange? Range { get; set; }
}