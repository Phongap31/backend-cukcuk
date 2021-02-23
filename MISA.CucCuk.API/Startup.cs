using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MISA.CukCuk.Common.Enums;
using MISA.CukCuk.DataLayer.Base;
using MISA.CukCuk.DataLayer.DbContext;
using MISA.CukCuk.DataLayer.Entities;
using MISA.CukCuk.DataLayer.Interfaces;
using MISA.CukCuk.Service.Base;
using MISA.CukCuk.Service.Entities;
using MISA.CukCuk.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace MISA.CucCuk.API
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

            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Employee Service API",
                    Description = "ASP.NET Core support API for MISA.CukCuk Employee Service",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //DI
            services.AddScoped(typeof(IDbContext<>), typeof(DapperDbContext<>));
            services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            //services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));

            services.AddScoped<IEmployeeDL, EmployeeDL>();
            services.AddScoped<IEmployeeService, EmployeeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Service API V1");
            });

            app.UseRouting();
            app.UseCors("AllowOrigin");

            // xử lý exception chung
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                var errorMsg = new ErrorMsg();
                errorMsg.DevMsg = exception.Message;
                errorMsg.UserMsg = UserMsg.DefaultUserMsg;
                
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorMsg));
                //await context.Response.WriteAsJsonAsync(new { error = exception.Message });
            }));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
