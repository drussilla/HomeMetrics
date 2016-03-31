using HomeMetrics.Collector.DAL.EF.Repositories;
using HomeMetrics.Collector.DAL.Repositories;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HomeMetrics.Collector.DAL.EF
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseEFContext(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SessionMiddleware>();
        }

        public static IServiceCollection AddEF(this IServiceCollection services)
        {
            services.AddEntityFramework();
            services.AddScoped<IDbContextProvider, LazyDbContextProvider>();
            services.AddScoped<ISensorRepository, SensorRepository>();
            services.AddScoped<IReadingRepository, ReadingRepository>();
            return services;
        }
    }
}