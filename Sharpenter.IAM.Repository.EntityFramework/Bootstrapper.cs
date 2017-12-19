using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sharpenter.IAM.Repository.EntityFramework.User;
using Sharpenter.IAM.UseCases;
using Sharpenter.IAM.UseCases.User;

namespace Sharpenter.IAM.Repository.EntityFramework
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
            RegisterDependencies(services);
            
            services.AddDbContext<IdentityContext>(options => 
                options.UseSqlServer(_configuration.GetConnectionString("Sharpenter.IAM")));
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public void ConfigureDevelopment(IdentityContext context)
        {
            DbInitializer.Seed(context);
        }
    }
}