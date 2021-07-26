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
using NetCORE_Api;
using NetCORE_Api.Service;
using NetCORE_Api.Service.Nums;

namespace WebApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            //services.AddScoped<IFactory, Api>();   
            services.AddScoped<IFactory, Back>();
            services.AddScoped<IFactory, Clear>();
            services.AddScoped<IFactory, Dot>();
            services.AddScoped<IFactory, Div>();
            services.AddScoped<IFactory, Multi>();
            services.AddScoped<IFactory, Plus>();
            services.AddScoped<IFactory, Sub>();
            services.AddScoped<IFactory, Negative>();
            services.AddScoped<IFactory, SquareRoot>();
            services.AddScoped<IFactory, LeftMark>();
            services.AddScoped<IFactory, RightMark>();
            //services.AddScoped<IFactory, Equal>();   
            services.AddScoped<IFactory, Zero>();
            services.AddScoped<IFactory, One>();
            services.AddScoped<IFactory, Second>();
            services.AddScoped<IFactory, Three>();
            services.AddScoped<IFactory, Four>();
            services.AddScoped<IFactory, Five>();
            services.AddScoped<IFactory, Six>();
            services.AddScoped<IFactory, Seven>();
            services.AddScoped<IFactory, Eight>();
            services.AddScoped<IFactory, Nine>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
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
