using Eticaret.Business.Abstract;
using Eticaret.Business.Concrete;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete.EntityFramework;
using Eticaret.MVCUI.Entities;
using Eticaret.MVCUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MVCUI
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
            //servisler scoped,singleton,transient olarak tanýmlanýr
            // singleton bir kere instance oluþur herkes ayný instance kullanýr
            //scoped ise nesne ornekleri yapoýlan her istekte yeniden oluþur
            // transient se ayný anda 2 istek ihtiyacý duyarsa 2 tane ayrý pier oluþturulur
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<ICartSessionServices, CartSesionService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer("Data Source = DESKTOP-ROTCU0Q; Initial Catalog = Northwind; Integrated Security = True"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();
            //// SESSÝON için alttaki 2 middleware yapýlandýrýlýr
            services.AddSession();
            services.AddDistributedMemoryCache(); //sessiion için
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApplicationBuilder applicationBuilder)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseRouting();
           
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
