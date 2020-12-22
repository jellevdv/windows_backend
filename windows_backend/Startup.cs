using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using windows_backend.Data;
using windows_backend.Data.Repositories;
using windows_backend.Models;
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
