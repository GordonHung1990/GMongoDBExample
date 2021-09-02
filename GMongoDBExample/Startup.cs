using GMongoDBExample.Domains.ConfigurationSettings.MongoDB;
using GMongoDBExample.Domains.Connections.MongoDB;
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GMongoDBExample
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
            services
                .AddOptions()
                .AddMongoDBConnection((options, sp) =>
                {
                    var config = sp.GetRequiredService<IConfiguration>();

                    config.GetSection("MongoDB").Bind(options);
                })
                .AddRepositories()
                .AddServices();
            services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "GMongoDBExample.xml");
                c.IncludeXmlComments(filePath);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GMongoDBExample", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GMongoDBExample v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
