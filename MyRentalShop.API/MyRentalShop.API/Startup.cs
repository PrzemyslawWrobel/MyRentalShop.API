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
using MyRentalShop.Persistance;
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
            //Dodanie CORS 
            services.AddCors(options =>
                options.AddPolicy(name: "MyAllowAngularOrigins",
                    builder =>
                    {
                        
                        builder.WithOrigins(
                            "http://localhost:4200",    //na jakim adresie bêdzie dzia³a³ FRONT-END

                            "http://localhost:5001"     //na jakim adresie bêdzie dzia³a³ serwer uwierzytelniaj¹cy
                            );                  
                    }
                )
            );

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://localhost:5001";
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateAudience = false // w przysz³oœci zmieniæ na true - walidacja sk¹d przychodzi token
                    };


                });


            services.AddControllers();
            services.AddInfrastructure(Configuration);
            services.AddPersistance(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
                    Title = "MyRentalShop.API", 
                    Version = "v1",
                    Description = "Aplikacja do zarz¹dzania wypo¿yczalni¹",
                    //TODO Zmieniæ na stronê w³aœciw¹ po utworzeniu
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Przemys³aw Wróbel",
                        Email = string.Empty,
                        Url = new Uri("https://example.com/terms")
                    },
                    License = new OpenApiLicense
                    {
                        //TODO Zmieniæ na w³aœciw¹ licencjê
                        Name = "Nazwa licencji",
                        Url = new Uri("https://example.com/license")
                    }
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "MyRentalShop.API.xml");
                c.IncludeXmlComments(filePath);
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api1");
                });
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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
