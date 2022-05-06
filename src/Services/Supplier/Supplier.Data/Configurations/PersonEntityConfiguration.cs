using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supplier.Domain.Entities;

namespace Supplier.Data.Configurations
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            builder.Property(x => x.Document)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            builder.HasMany(x => x.Contacts)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId)
                .IsRequired();
        }
    }
}
