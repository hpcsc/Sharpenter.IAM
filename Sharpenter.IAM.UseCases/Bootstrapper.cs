using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sharpenter.IAM.UseCases.User;

namespace Sharpenter.IAM.UseCases
{
    public class Bootstrapper
    {
        private readonly IConfiguration _configuration;

        public Bootstrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureContainer(IServiceCollection services)
        {
            services.AddScoped<IListUserInteractor, ListUserInteractor>();
        }
    }
}