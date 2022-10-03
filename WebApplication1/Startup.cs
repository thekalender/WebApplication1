using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services.Logging;

namespace WebApplication1
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
            services.AddRazorPages();
            services.AddMvc();

            services.AddSingleton<ILogger, DataBaseLogger>();  //Dependency Injection

            services.AddSession(); //KSoft Session
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=home}/{action=index}/{id?}"
            //        );
            //});

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // Bu bizim wwwroot daki bootstrap jquery kütüphanesini kullanmamýzý saðlar.

            app.UseSession(); //KSoft Session

            app.UseRouting();

            app.UseAuthorization();

            //KSoft_Ahk_start
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            //KSoft_Ahk_end

            //KSoft_Ahk_start
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "admin",
                           pattern: "admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(name: "Ahmet",
                            pattern: "Ahmet/{*deger}",
                            defaults: new { controller = "Home", action = "RazorDemo" });

                endpoints.MapControllerRoute(name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //KSoft_Ahk_end


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
