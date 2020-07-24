using System;
using LPLMVC.Areas.Identity.Data;
using LPLMVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LPLMVC.Areas.Identity.IdentityHostingStartup))]
namespace LPLMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LPLMVCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LPLMVCContextConnection")));

                services.AddDefaultIdentity<LPLMVCUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>().AddEntityFrameworkStores<LPLMVCContext>();
            });
        }
    }
}