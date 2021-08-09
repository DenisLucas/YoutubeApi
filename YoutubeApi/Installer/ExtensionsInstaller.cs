using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation;

namespace YoutubeApi.Installer
{
    public static class ExtensionsInstaller
    {
        public static void InstallServicesInAssembly(this IServiceCollection services,IConfiguration Configuration)
        {
            var installer = typeof(Startup).Assembly.GetExportedTypes().Where(x=> typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installer.ForEach(x=> x.InstallServices(services, Configuration));
        }
    }
}