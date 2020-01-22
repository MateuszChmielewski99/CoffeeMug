using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CofeeMug.Infrastructure.Commands;
using CofeeMug.Infrastructure.Handlers;
using CofeeMug.Infrastructure.Mongo;
using CofeeMug.Infrastructure.Repositories;
using CofeeMug.Infrastructure.Services;
using CoffeeMug.Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CoffeeMug
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
            services.AddMongoDb(options =>
            {
                options.ConnectionString = "mongodb://192.168.99.100:27017";
                options.Database = "CoffeeMug-Products";
            });
            services.AddScoped<ICommandHandler<UpdateProductCommand>, UpdateProductHandler>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductHandler>();
            services.AddScoped<ICommandHandler<DeleteProductCommand>, DeleteProductHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllers();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Api V1");
                c.RoutePrefix = string.Empty;
            });

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
