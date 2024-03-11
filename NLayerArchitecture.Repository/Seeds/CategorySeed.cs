using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerArchitecture.Core.Models;

namespace DataHub.Repository.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Teknoloji" },
                new Category { Id = 2, Name = "Sağlık" },
                new Category { Id = 3, Name = "Ulaşım" });
        }
    }
}
