using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace D_KSRTC.Data
{
    // It's good practice to have a summary or description of the class here.
    public class DKSRTCContext : DbContext
    {
        public DKSRTCContext(DbContextOptions<DKSRTCContext> options) : base(options) { }

        // DbSet for LocationDetails entity.
        // Consider adding comments or summaries to your properties.
        public DbSet<Models.LocationDetails> LocationDetails { get; set; }
        public DbSet<Models.BusType> BusType { get; set; }
        public DbSet<Models.BusCategory> BusCategory { get; set; }
        public DbSet<Models.BusTypeCategory> BusTypeCategory { get; set; }
        public DbSet<Models.Bus> Bus { get; set; }
        public DbSet<Models.Time> Time { get; set; }
        public DbSet<Models.Route> Route { get; set; }
        public DbSet<Models.RouteDetails> RouteDetails { get; set; }
        public DbSet<Models.BusRoute> BusRoute { get; set; }
        public DbSet<Models.User> User { get; set; }
        public DbSet<Models.Booking> Booking { get; set; }
        public DbSet<Models.Seat> Seat { get; set; }
        public DbSet<Models.Passenger> Passenger { get; set; }
        public DbSet<Models.Payment> Payment { get; set; }
        public DbSet<Models.Billing> Billing { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BusTypeCategory>().HasOne(x => x.TypeIdNavigaton)
            //    .WithMany(x => x.BusTypeCategories)
            //    .HasForeignKey(x => x.TypeId);
            //modelBuilder.Entity<BusTypeCategory>().HasOne(x => x.CategoryIdNavigaton)
            //   .WithMany(x => x.BusTypeCategories)
            //   .HasForeignKey(x => x.CategoryId);
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var assemblyName = Assembly.GetExecutingAssembly();
        //    if (assemblyName is not null) modelBuilder.ApplyConfigurationsFromAssembly(assemblyName);
        //    foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
        //    { entity.GetForeignKeys().Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade).ToList().ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict); }
        //}

    }
}
