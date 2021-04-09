using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyRentalShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyRentalShop.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Dodanie CORS na jakim adresie b�dzie dzia�a� FRONT-END
            //services.AddCors(options =>
            //    options.AddPolicy(name: "MyAllowSpecificOrigins",
            //        builder =>
            //        {
                        
            //            builder.WithOrigins("https://localhost:4200");
            //        }
            //    )
            //);

            services.AddControllers();
            services.AddInfrastructure(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
                    Title = "MyRentalShop.API", 
                    Version = "v1",
                    Description = "Aplikacja do zarz�dzania wypo�yczalni�",
                    //TODO Zmieni� na stron� w�a�ciw� po utworzeniu
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Przemys�aw Wr�bel",
                        Email = string.Empty,
                        Url = new Uri("https://example.com/terms")
                    },
                    License = new OpenApiLicense
                    {
                        //TODO Zmieni� na w�a�ciw� licencj�
                        Name = "Nazwa licencji",
                        Url = new Uri("https://example.com/license")
                    }
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "MyRentalShop.API.xml");
                c.IncludeXmlComments(filePath);
            });

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyRentalShop.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
