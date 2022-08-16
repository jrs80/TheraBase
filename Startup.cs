using Microsoft.AspNetCore.Builder;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using TherapistDatabase.Models;

namespace TherapistDatabase
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection svc)
        {
            svc.AddScoped<IDbConnection>((s) => 
            { IDbConnection c = new MySqlConnection(Configuration.GetConnectionString("prairiecare"));
                c.Open();
                return c;
            });
            svc.AddTransient<IProviderRepository, ProviderRepository>();
            svc.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");                
                });
        }
    }
}
