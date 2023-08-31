using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D_KSRTC.Data.Configurations
{
    public class BusTypeCategoryConfiguration : IEntityTypeConfiguration<BusTypeCategory>
    {
        public void Configure(EntityTypeBuilder<BusTypeCategory> builder)
        {
        }
    }
}
