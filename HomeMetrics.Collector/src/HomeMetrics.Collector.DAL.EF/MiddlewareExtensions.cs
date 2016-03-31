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
            return services;
        }
    }
}