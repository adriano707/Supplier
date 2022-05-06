using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supplier.Domain.Entities;

namespace Supplier.Data.Configurations
{
    public class JuridicalPersonEntityConfiguration : IEntityTypeConfiguration<JuridicalPerson>
    {
        public void Configure(EntityTypeBuilder<JuridicalPerson> builder)
        {
            builder.ToTable("JuridicalPerson");

            builder.Property(x => x.TradeName)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(x => x.WebSite)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(x => x.ShareQuantity)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(x => x.CompanyTypeId)
                .IsRequired();
            builder.HasOne(x => x.CompanyType)
                .WithMany()
                .HasForeignKey(x => x.CompanyTypeId);

            builder.Property(x => x.CompanySizeId)
                .IsRequired();
            builder.HasOne(x => x.CompanyType)
                .WithMany()
                .HasForeignKey(x => x.CompanySizeId);
        }
    }
}
