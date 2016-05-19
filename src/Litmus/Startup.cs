
using Litmus.Entities;
using Litmus.Services;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Litmus
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        //public IConfigurationRoot Configuration { get; set; }
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
               .AddJsonOptions(options =>
               {
                   options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
               });
            services.AddCors();

            services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<LitmusDbContext>(options => options.UseSqlServer(Configuration["database:connection"]));

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddSingleton(provider => Configuration);

            services.AddScoped<ICardData, SqlCardData>();
            services.AddScoped<ILogData, SqlLogData>();
            services.AddScoped<ILocationData, LocationData>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseIISPlatformHandler();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseFileServer();

            //Mapper.Initialize(config => { config.CreateMap<Trip, TripViewModel>().ReverseMap(); });

            app.UseCors(builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod()
            );

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
