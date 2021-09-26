using ConsumerMicroservice.Data;
using ConsumerMicroservice.Repository;
using ConsumerMicroservice.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice
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
            services.AddTransient<IConsumerService, ConsumerService>();
            services.AddTransient<IConsumerRepository, ConsumerRepository>();
            services.AddHttpClient();
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer("Server=tcp:policyadministration.database.windows.net,1433;Initial Catalog=PolicyAdministration;Persist Security Info=False;User ID=namrata;Password=admin@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Consumer MicroService",
                });
            });

    //   services.AddCors(c => c.AddPolicy("PolicyAdministrationSystem", builder =>
    //   {
    //     builder.AllowAnyOrigin();
    //     builder.AllowAnyMethod();
    //     builder.AllowAnyHeader();
    //   }));


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "Consumer MicroService"));

            app.UseHttpsRedirection();
            // app.UseCors("PolicyAdministrationSystem");


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
