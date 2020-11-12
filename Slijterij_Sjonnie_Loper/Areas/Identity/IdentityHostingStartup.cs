using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Slijterij_Sjonnie_Loper.Data;

[assembly: HostingStartup(typeof(Slijterij_Sjonnie_Loper.Areas.Identity.IdentityHostingStartup))]
namespace Slijterij_Sjonnie_Loper.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Slijterij_Sjonnie_LoperContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Slijterij_Sjonnie_LoperContextConnection")));

                services.AddIdentity<Staff, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequiredLength = 3;
                })
                    .AddEntityFrameworkStores<Slijterij_Sjonnie_LoperContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<Staff>, ApplicationUserclaimsPrincipalFactory>();
            });
        }
    }
}