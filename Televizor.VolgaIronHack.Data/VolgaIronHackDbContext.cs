using Microsoft.EntityFrameworkCore;

namespace Televizor.VolgaIronHack.Entities;

public class VolgaIronHackDbContext : DbContext
{
    public VolgaIronHackDbContext(DbContextOptions options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Id);

        var parcel = modelBuilder.Entity<Delivery>();
        parcel.HasKey(p => p.Id);
        
        var parcelDeliveryRequest = modelBuilder.Entity<DeliveryRequest>();
        parcelDeliveryRequest.HasKey(pdr => pdr.Id);

        var station = modelBuilder.Entity<Station>();
        station.HasKey(s => s.Id);

        var trainRoute = modelBuilder.Entity<TrainRoute>();
        trainRoute.HasKey(tr => tr.Id);
        trainRoute.HasMany<TrainRouteStop>();
        
        var trainRouteStop = modelBuilder.Entity<TrainRouteStop>();
        trainRouteStop.HasKey(tr => tr.Id);
        trainRouteStop.HasOne<TrainRoute>().WithMany(route => route.Stops).HasForeignKey(stop => stop.TrainRouteId);

        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Delivery?> Deliveries { get; set; }
    
    public DbSet<User?> Users { get; set; }
    
    public DbSet<DeliveryRequest?> DeliveryRequests { get; set; }
    
    public DbSet<Station?> Stations { get; set; }
    
    public DbSet<TrainRoute?> TrainRoutes { get; set; }
    
    public DbSet<TrainRouteStop?> TrainRouteStops { get; set; }
    
    public DbSet<TrainTrip?> TrainTrips { get; set; }
    
    public DbSet<DeliveryStatusChange> StatusChanges { get; set; }
}