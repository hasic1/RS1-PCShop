using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PC_Shop.Database;
using PC_Shop_classLibrary.Service;
using PC_Shop_classLibrary.Service.Interface;
using PC_Shop_classLibrary.Migrations;

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

            
            services.AddAutoMapper(typeof(Startup));

            var connectionString = Configuration.GetConnectionString("connection");
            services.AddDbContext<Context>(builder => builder.UseSqlServer(connectionString));
            //Dodaj ovde kad pravis Get ili Post ovde moras ovo dodat isto se dodaje samo mjenjas ovo u zagradama
            services.AddScoped<IBankaService, BankaService>();
            services.AddScoped<IProizvodService, ProizvodService>();
            services.AddScoped<INarudzbaService, NarudzbaService>();

            services.AddSwaggerGen();
            services.AddControllers();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseSwagger();
           

            app.UseAuthorization();
            app.UseRouting();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors(
              options => options
              .SetIsOriginAllowed(x => _ = true)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
          ); //This needs to set everything allowed


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}