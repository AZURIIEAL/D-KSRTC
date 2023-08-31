using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D_KSRTC.Data.Configurations
{
    public class BusTypeConfigaration : IEntityTypeConfiguration<BusType>
    {
        public void Configure(EntityTypeBuilder<BusType> builder)
        {
            builder.Property(x => x.TypeName).IsRequired();
            builder.Property(x => x.TypeName).HasMaxLength(100);
        }
    }
}
