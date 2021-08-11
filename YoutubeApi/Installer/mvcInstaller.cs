using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Presentation;
using Application.Filters;
using Application;

namespace YoutubeApi.Installer
{
    public class mvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddMvc(options=> 
                options.Filters.Add<ValidationFilter>());
            services.AddFluentValidation(mvcConfiguration=> mvcConfiguration.RegisterValidatorsFromAssemblyContaining<AppDBContext>());

            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YoutubeApi", Version = "v1" });
            });
        }
    }
}