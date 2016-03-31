using HomeMetrics.Collector.DAL.EF;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HomeMetrics.Collector.API
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;

            var builder = new ConfigurationBuilder()
            //    .AddJsonFile("config.json")
            //    .AddJsonFile($"config.{_hostingEnv.EnvironmentName}.json", optional: true)
                .AddUserSecrets();

            _configuration = builder.Build();
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MvcJsonOptions>(options =>
            {
                if (_hostingEnv.IsDevelopment())
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                }

                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddMvc();

            services.AddSingleton(_ => _configuration);

            services.AddEF();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseEFContext();

            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "api",
                    template: "api/{controller}/{action=GetAll}/{id?}");
            });

            var logger = loggerFactory.CreateLogger("Startup");
            logger.LogInformation("Application initialized");
            logger.LogInformation($"Environment: {_hostingEnv.EnvironmentName}");

            logger.LogInformation("Database name: " + _configuration["Data:DefaultConnection:Database"]);
        }
    }
}
