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

            services.AddSingleton<IReadOnlyDictionary<string, IFactory>>(new Dictionary<string, IFactory>()
            {
                {"api", new Api()},
                {"Back", new Back()},
                {"C", new Clear()},
                {".", new Dot()},
                {"+", new Plus()},
                {"-", new Sub()},
                {"*", new Multi()},
                {"/", new Div()},
                {"=", new Equal()},
                {"+/-", new Negative()},
                {"(", new LeftMark()},
                {")", new RightMark()},
                {"กิ", new SquareRoot()},
                {"0", new Zero()},
                {"1", new One()},
                {"2", new Second()},
                {"3", new Three()},
                {"4", new Four()},
                {"5", new Five()},
                {"6", new Six()},
                {"7", new Seven()},
                {"8", new Eight()},
                {"9", new Nine()},
            });
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
