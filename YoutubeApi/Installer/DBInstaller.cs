using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;

namespace YoutubeApi.Installer
{
    public class DBInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                b => b.MigrationsAssembly("Presentation")));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}