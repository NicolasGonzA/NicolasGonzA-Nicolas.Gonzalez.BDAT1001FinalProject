using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Private_API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace Private_API
{
    public class Startup
    {


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("WebAuth")
                .AddCookie("WebAuth", config =>
                {
                    config.Cookie.Name = "PrivateAPI";
                    config.LoginPath = "/Home/Authenticate";
                });

            services.AddControllersWithViews();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseRouting();
            // are you allowed?
            app.UseAuthentication();

            // who are you?
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>

            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
