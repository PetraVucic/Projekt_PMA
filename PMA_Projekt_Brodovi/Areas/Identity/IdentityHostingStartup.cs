using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMA_Projekt_Brodovi.Areas.Identity.Data;
using PMA_Projekt_Brodovi.Data;

[assembly: HostingStartup(typeof(PMA_Projekt_Brodovi.Areas.Identity.IdentityHostingStartup))]
namespace PMA_Projekt_Brodovi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PMA_Projekt_BrodoviContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShipConnection")));

                services.AddDefaultIdentity<PMA_Projekt_BrodoviUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<PMA_Projekt_BrodoviContext>();
            });
        }
    }
}