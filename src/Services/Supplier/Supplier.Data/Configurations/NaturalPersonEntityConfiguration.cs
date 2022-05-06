using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supplier.Domain.Entities;

namespace Supplier.Data.Configurations
{
    public class NaturalPersonEntityConfiguration : IEntityTypeConfiguration<NaturalPerson>
    {
        public void Configure(EntityTypeBuilder<NaturalPerson> builder)
        {
            builder.ToTable("NaturalPerson");          

            builder.Property(x => x.Profession)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(x => x.Nationality)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(x => x.CompanyTypeId)
                .IsRequired();
            builder.HasOne(x => x.CompanyType)
                .WithMany()
                .HasForeignKey(x => x.CompanyTypeId);
        }
    }
}
