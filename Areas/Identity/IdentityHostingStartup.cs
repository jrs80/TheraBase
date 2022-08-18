﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TherapistDatabase.Data;

[assembly: HostingStartup(typeof(TherapistDatabase.Areas.Identity.IdentityHostingStartup))]
namespace TherapistDatabase.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TherapistDatabaseContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TherapistDatabaseContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TherapistDatabaseContext>();
            });
        }
    }
}
