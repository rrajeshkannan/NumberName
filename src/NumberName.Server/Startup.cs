using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberName.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                var (apiModuleName, apiModuleVersion) = ModuleInfo;
                c.SwaggerDoc("v1", new OpenApiInfo { Title = apiModuleName, Version = apiModuleVersion });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                var (apiModuleName, apiModuleVersion) = ModuleInfo;
                var apiModule = $"{apiModuleName} {apiModuleVersion}";
                app.UseSwaggerUI(c => c.SwaggerEndpoint(SwaggerUrl, apiModule));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Api Module <-> Swagger Configuration

        private (string Name, string Version) ModuleInfo =>
            (Configuration["ApiModule:Name"], Configuration["ApiModule:Version"]);

        private string SwaggerUrl => Configuration["SwaggerUrl"];

        #endregion
    }
}