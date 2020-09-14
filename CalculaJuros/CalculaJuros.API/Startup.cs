using System;
using System.IO;
using System.Reflection;
using CalculaJuros.Core.Calculadora.Interfaces;
using CalculaJuros.Core.Calculadora.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Refit;

namespace CalculaJuros.API
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
            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Calcula Juros",
                        Description = "API para realizar o calculo de Juros",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Lucas Soares",
                            Email = "Lucas_ssoares@live.com",
                            Url = new Uri("https://www.linkedin.com/in/lucassoares1/"),
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                _.IncludeXmlComments(xmlPath);
            });
            services.AddScoped<ICalculaJurosService, CalculaJurosService>();

            var configurationSection = Configuration.GetSection("ExternalServices:TaxaJuros");

            services
                .AddRefitClient<ITaxaJurosService>()
                .ConfigureHttpClient(_ => _.BaseAddress = new Uri(configurationSection.Value));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(_ => { _.SwaggerEndpoint("/swagger/v1/swagger.json", "Calcula Juros"); });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async context => {
                context.Response.Redirect("swagger/index.html");
            });
        }
    }
}
