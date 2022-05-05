using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Supplier.Data.Contexts;

namespace Supplier.Data
{
    public static class DataStartup
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<SupplierDbContext>(opt => opt.UseSqlServer("server=localhost;user id=sa;password=21080621;database=db_supplier"));

            services.AddScoped<SupplierDbContext>();
        }
    }
}
