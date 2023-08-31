using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D_KSRTC.Data.Configuration
{
    public class BusCategoryConfiguration : IEntityTypeConfiguration<BusCategory>
    {
        public void Configure(EntityTypeBuilder<BusCategory> builder)
        {
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.BaseFare).IsRequired();
        }
    }
}
