using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supplier.Domain.Entities;

namespace Supplier.Data.Configurations
{
    internal class PersonContactEntityConfiguration : IEntityTypeConfiguration<PersonContact>
    {
        public void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.ToTable("PersonContact");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Contact)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
