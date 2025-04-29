using Common.Interfaces;
using DAL.Concrete;
using DAL.Context.EF;
using DAL.UnitOfWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class DalExtension
    {
        public static IServiceCollection LoadDalExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<BECPContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IUow, Uow>();

            return services;
        }
    }
}
