using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerArchitecture.Core.Models;

namespace DataHub.Repository.Seeds
{
    internal class CompanySeed : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(new Company
            {
                Id = 1,
                CategoryId = 1,
                Name = "Meta",
                Industry = "Teknoloji",
            },
            new Company
            {
                Id = 2,
                CategoryId = 1,
                Name = "Alphabet",
                Industry = "Teknoloji",
            });
        }
    }
}
