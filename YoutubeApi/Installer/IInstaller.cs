using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YoutubeApi.Installer
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services,IConfiguration configuration);
    }
}