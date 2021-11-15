using Desafio.AMcom.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace Desafio.AMcom
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string _policyName = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddScoped<IPaisesService, PaisesService>();
            services.AddScoped<ITemperaturaService, TemperaturaService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddMemoryCache();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio.AMcom", Version = "v1" });

            });



            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.RoutePrefix = "swagger";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio.AMcom v1");
                    
                    });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseCors(_policyName);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
