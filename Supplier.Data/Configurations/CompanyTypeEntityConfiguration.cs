using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supplier.Domain.Entities;

namespace Supplier.Data.Configurations
{
    public class CompanyTypeEntityConfiguration : IEntityTypeConfiguration<CompanyType>
    {
        public void Configure(EntityTypeBuilder<CompanyType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(100)");
        }
    }
}
