using BeerCollection.Middlewares;
using BLL.Services.Implementation;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Implementation;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BeerCollection.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureAddDbContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<BeerCollectionContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.EnableDetailedErrors(true);
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure(3);
                    sqlServerOptions.CommandTimeout(60);
                });
            }, ServiceLifetime.Scoped
            );
        }

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            #region Services
            services.AddHttpContextAccessor();
            services.AddTransient<IBeerCollectionService, BeerCollectionService>();
            #endregion

            #region Repositories
            services.AddTransient<IBeerCollectionRepository, BeerCollectionRepository>();
            #endregion

            services.AddTransient<ExceptionMiddleware>();

        }
    }
}
