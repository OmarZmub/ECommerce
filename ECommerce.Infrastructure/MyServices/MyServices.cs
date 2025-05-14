using ECommerce.Busniss_Logic.IunitofWork;
using ECommerce.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // ✅ Correct namespace
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.MyServices
{
    public static class MYServices
    {
        public static void AddMyServices(this IServiceCollection services, IConfiguration config)
        {
            string ConnectionString = config.GetConnectionString("costr"); 

            services.AddDbContext<database>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(ConnectionString));

            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<database>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUnitofWork, UnitofWork>();
        }
    }
}