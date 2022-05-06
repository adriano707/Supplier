using Microsoft.EntityFrameworkCore;
using Supplier.Domain.Entities;
using System.Reflection;

namespace Supplier.Data.Contexts
{
    public class SupplierDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }       
        public DbSet<PersonContact> PersonContact { get; set; }
        public DbSet<CompanyType> CompanyType { get; set; }
        public DbSet<CompanySize> CompanySize { get; set; }

        public SupplierDbContext()
        {

        }

        public SupplierDbContext(DbContextOptions<SupplierDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
