using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D_KSRTC.Data.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Models.Route>
    {
        public void Configure(EntityTypeBuilder<Models.Route> builder)
        {
            throw new NotImplementedException();
        }
    }
}
