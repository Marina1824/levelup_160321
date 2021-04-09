using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Bill.Managemen.Rest.Service.Services.MapService;
using Bill.Management.Core.Abstractions;
using Bill.Management.Core.Implementations;
using Bill.Management.Implementations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bill.Managemen.Rest.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddLogger()
                .AddJson()
                .AddEntitiesValidation()
                .AddSqlRepositories()
                .AddCollectionManagers()
                .AddMapService<BillAutomapService>();

            services.AddSwaggerGen(arg =>
            {
                arg.SwaggerDoc("bill_management_v1", new OpenApiInfo()
                {
                    Version = "V1",
                    Title = "Bill Management API Service",
                    Description = "Simple bill management service"
                });

                arg.SwaggerDoc("bill_management_v2", new OpenApiInfo()
                {
                    Version = "V2",
                    Title = "Bill Management API Service",
                    Description = "Simple bill management service"
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                arg.IncludeXmlComments(xmlPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/bill_management_v1/swagger.json", "Bill Management Service V1");
                c.SwaggerEndpoint("/swagger/bill_management_v2/swagger.json", "Bill Management Service V2");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
