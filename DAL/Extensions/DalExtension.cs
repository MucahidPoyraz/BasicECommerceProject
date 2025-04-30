using Common.Interfaces;
using DAL.Concrete;
using DAL.Context.EF;
using DAL.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DAL.Extensions
{
    public static class DalExtension
    {
        public static IServiceCollection LoadDalExtension(this IServiceCollection services, IConfiguration config)
        {
            // DbContext servisini ekliyoruz
            services.AddDbContext<BECPContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Local")));

            // Generic repository için DI
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // UnitOfWork için DI
            services.AddScoped<IUow, Uow>();

            return services;
        }
    }
}
