using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D_KSRTC.Data.Configurations
{
    public class LocationDetailsConfiguration : IEntityTypeConfiguration<LocationDetails>
    {
        public void Configure(EntityTypeBuilder<LocationDetails> builder)
        {
            builder.Property(x => x.LocationName).IsRequired();
            builder.Property(x => x.LocationName).HasMaxLength(100);
        }
    }
}
