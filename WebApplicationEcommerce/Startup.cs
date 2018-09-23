using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebShopServices;
using WebShopLibrary.Interfaces;
using WebShopDataStorage.Models;
using Microsoft.IdentityModel.Protocols;
using System.Data.SqlClient;

namespace WebApplicationEcommerce
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IProductsServices, ProductService>();
            services.AddScoped<ICategoriesServices, CategoriesService>();

            

            string conString =
   ConfigurationExtensions
   .GetConnectionString(this.Configuration, "WebShopConnection");

            services.AddDbContext<WebShopLibrary.ShopDataStorageContext>(options =>
            options.UseSqlServer(conString));//Configuration.GetConnectionString("WebShopConnection")));

            Boolean result = checkConnectionString(conString);


        }

        public static bool checkConnectionString(string con)
        {
            if ( !checkConnectionStringValidity(con))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static bool checkConnectionStringValidity(string con)
        {
            try
            {
                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
