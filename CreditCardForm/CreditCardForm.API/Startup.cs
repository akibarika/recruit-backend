using System;
using System.IO;
using System.Reflection;
using CreditCardForm.DataAccess.Concrete;
using CreditCardForm.DataAccess.Interface;
using CreditCardForm.Model;
using CreditCardForm.Service.Concrete;
using CreditCardForm.Service.Interface;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CreditCardForm.API
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                });
            });

            services.AddScoped<ICreditCardFormService, CreditCardFormService>();
            services.AddScoped<ICreditCardFormRepository, CreditCardFormRepository>();
            services.Configure<CreditCardFormDatabaseSettings>(
                Configuration.GetSection(nameof(CreditCardFormDatabaseSettings)));
            services.AddSingleton<ICreditCardFormDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CreditCardFormDatabaseSettings>>().Value);
            services.AddControllers().AddFluentValidation();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Credit Card Form",
                    Version = "v1",
                    Description = "API Development Document for Credit Card Form App",
                    Contact = new OpenApiContact
                    {
                        Name = "Sawyer Lu",
                        Email = "lxclxc89816@gmail.com"
                    }
                });
                
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditCardForm v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}