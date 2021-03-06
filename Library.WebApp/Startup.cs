using static Library.Common.GlobalVariables;

using Library.Common;
using Library.Data;
using Library.Data.Entities;
using Library.Data.Repositories;
using Library.Data.Repositories.Abstractions;
using Library.Data.Repositories.Uow;
using Library.Data.Repositories.Uow.Abstractions;
using Library.Services;
using Library.Services.Abstractions;
using Library.Services.Extensions;
using Library.WebApp.Helpers.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp
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
            services.AddControllersWithViews();

            services.AddDbContext<LibraryDbContext>(options =>
            {
                //options.UseSqlServer(Configuration.GetConnectionString("someeDb")
                //options.UseSqlServer(Configuration.GetConnectionString("saatecDB")
                options.UseSqlServer(Configuration.GetConnectionString("localDB")
                    , migration => migration.MigrationsAssembly("Library.Data"));
            });

            services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<LibraryDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/auth/login";
                options.LogoutPath = "/auth/logout";
                options.AccessDeniedPath = "/auth/accessdenied";
                options.Cookie.Name = LibraryWebCookieName;
            });

            services.AddAntiforgery(options =>
            {
                options.Cookie.Name = AntiForgeryCoockieName;
            });

            services.AddScoped<IUnitOfWorks, UnitOfWorks>();

            services.AddApplicationServices();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseDatabaseMigration();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
