using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PC_Shop.Database;
using PC_Shop_classLibrary.Service;
using PC_Shop_classLibrary.Service.Interface;

namespace PC_Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            var connectionString = Configuration.GetConnectionString("connection");
            services.AddDbContext<Context>(builder => builder.UseSqlServer(connectionString));

            services.AddScoped<IDrzavaService, DrzavaService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}