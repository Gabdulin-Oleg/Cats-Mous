using Cats_Mous.DBCats_Mous;
using Cats_Mous.Interdaces;
using Cats_Mous.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cats_Mous
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
            string conection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Context>(opt => opt.UseSqlServer(conection).EnableSensitiveDataLogging(true));
            //services.AddScoped<IRepository, Operations>();
            //services.AddTransient<ISettingOrder, SettingOrder>();

            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=HomePage}/{action=Index}/{id?}");
            });
        }
    }
}
