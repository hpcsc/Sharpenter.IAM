using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Sharpenter.BootstrapperLoader.Builder;
using Sharpenter.BootstrapperLoader.Helpers;

namespace Sharpenter.IAM.UI.Web
{
    public class Startup
    {
        private readonly BootstrapperLoader.BootstrapperLoader _bootstrapperLoader;
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            
            _bootstrapperLoader = new LoaderBuilder()
                .Use(new FileSystemAssemblyProvider(PlatformServices.Default.Application.ApplicationBasePath, "Sharpenter.IAM*.dll"))
                .ForClass()
                    .HasConstructorParameter(_configuration)
                    .Methods()
                        .Call("ConfigureDevelopment").If(env.IsDevelopment)
                .Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            _bootstrapperLoader.Trigger("ConfigureContainer", services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new {controller = "Home", action = "Index"});
            });
            
            // need to create scope during application startup due to: https://stackoverflow.com/questions/44180773/dependency-injection-in-asp-net-core-2-thows-exception
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                _bootstrapperLoader.TriggerConfigure(scope.ServiceProvider.GetRequiredService);
            }
        }
    }
}