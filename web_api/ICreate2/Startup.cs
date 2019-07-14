using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ICreate2.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ICreate2
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
            services.AddDbContext<ICreateContext>(opt => opt.UseInMemoryDatabase("ICreate"));
            services.AddMvc();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*app.UseCors(
               builder => builder
               .AllowAnyHeader()
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowCredentials()
                );*/

            app.UseCors(
                builder => builder.WithOrigins("http://localhost:7777")
                .AllowAnyHeader()
                .AllowAnyMethod()
                );
            app.UseMvc();
            
        }
    }
}
