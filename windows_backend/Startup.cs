using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using windows_backend.Data;
using windows_backend.Data.Repositories;
using windows_backend.Models.Interfaces;

namespace windows_backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>();//options =>

            // options.UseSqlServer(Configuration.GetConnectionString("DataContext")).EnableSensitiveDataLogging());
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<DataInitializer>();
            services.AddControllers();
            /*
            services.AddSwaggerDocument();

            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "Back-End ApiTest";
                c.Version = "v1";
                c.Description = "Hier gaan we testen of de Back-End volledig werkt";
                c.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Copy 'Bearer' + valid JWT token into field"
                });
                c.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT")); //adds the token when a request is send
            });
            */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
