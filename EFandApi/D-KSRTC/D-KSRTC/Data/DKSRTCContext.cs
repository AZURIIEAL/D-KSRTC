using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Data
{
    // It's good practice to have a summary or description of the class here.
    public class DKSRTCContext : DbContext
    {
        public DKSRTCContext(DbContextOptions<DKSRTCContext> options) : base(options) { }

        // DbSet for LocationDetails entity.
        // Consider adding comments or summaries to your properties.
        public DbSet<Models.LocationDetails> LocationDetails { get; set; }
        public DbSet<Models.BusType> BusType{ get; set; }
        public DbSet<Models.BusCategory> BusCategory { get; set; }
        public DbSet<Models.BusTypeCategory> BusTypeCategory { get; set; }
        public DbSet<Models.Bus> Bus { get; set; }
        public DbSet<Models.User> User { get; set; }

    }
}
