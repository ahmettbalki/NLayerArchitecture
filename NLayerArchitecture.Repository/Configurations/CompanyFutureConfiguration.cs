using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerArchitecture.Core.Models;

namespace NLayerArchitecture.Repository.Configurations
{
    internal class CompanyFutureConfiguration : IEntityTypeConfiguration<CompanyFeature>
    {
        public void Configure(EntityTypeBuilder<CompanyFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Company).WithOne(x => x.CompanyFeature).HasForeignKey<CompanyFeature>(x => x.CompanyId);
        }
    }
}
