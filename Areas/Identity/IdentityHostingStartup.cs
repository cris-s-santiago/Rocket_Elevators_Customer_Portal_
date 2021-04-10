using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rocket_Elevators_Customer_Portal.Areas.Identity.Data;
using Rocket_Elevators_Customer_Portal.Data;

[assembly: HostingStartup(typeof(Rocket_Elevators_Customer_Portal.Areas.Identity.IdentityHostingStartup))]
namespace Rocket_Elevators_Customer_Portal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PortalDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PortalDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                    {
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                        options.SignIn.RequireConfirmedAccount = false;
                    }                
                )
                    .AddEntityFrameworkStores<PortalDbContext>();
            });
        }
    }
}