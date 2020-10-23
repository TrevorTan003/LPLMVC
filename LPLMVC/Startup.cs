using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LPLMVC.Data;
using LPLMVC.Models;
using Microsoft.Extensions.Options;
using LPLMVC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace LPLMVC
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
            services.AddDbContext<LPLMVCContext>(options =>
                   options.UseSqlServer(
                         Configuration.GetConnectionString("LPLMVCContextConnection")));

            services.AddDefaultIdentity<LPLMVCUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>().AddEntityFrameworkStores<LPLMVCContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //DbContext For TeamsContext
            services.AddDbContext<LPLTeamsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("LPLMVCContextConnection")));

            //Claims Policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CreateTeamPolicy",
                    policy => policy.RequireClaim("Create Team"));

                options.AddPolicy("EditTeamPolicy",
                    policy => policy.RequireClaim("Edit Team"));

                options.AddPolicy("DeleteTeamPolicy",
                    policy => policy.RequireClaim("Delete Team"));
            });
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
