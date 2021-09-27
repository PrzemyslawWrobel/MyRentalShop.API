using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyRentalShop.API.Service;
using MyRentalShop.Application;
using MyRentalShop.Application.Common.Interfaces;
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
                            "http://localhost:4200",    //na jakim adresie b�dzie dzia�a� FRONT-END

                            "http://localhost:5001"     //na jakim adresie b�dzie dzia�a� serwer uwierzytelniaj�cy
                            );                  
                    }
                )
            );
            //HttpContexxtAccessor dodajemy jeden raz dla ca�ej aplikacji, �eby by� niezmiennny i odp przechowywa� dane u�ytkownik�w, sesji i zapyta�
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // dodanie wskazania implementacji Current user
            services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001/"; //adres sk�d b�d� pobierane dane do uwierzytelnienia
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateAudience = false // w przysz�o�ci zmieni� na true - walidacja sk�d przychodzi token - zabezpiecza przed podszywaniem si�
                    };


                });


            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddPersistance(Configuration);
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                { 
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:5001/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"api1", "Full access" },
                                {"user1", "User info" },
                                { "openid", "Full "}
                            }
                        }
                    }
                });
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

            app.UseSwaggerUI(c => 
                {

                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyRentalShop.API v1");
                    c.OAuthClientId("swagger");
                    c.OAuth2RedirectUrl("https://localhost:44311/swagger/oauth2-redirect.html");
                    c.OAuthUsePkce(); // mechanizm do rozpoznawania czy token by� u�ywany przez inne aplikacje
                });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization("ApiScope"); //ca�a aplikacja -> wszystkie kontrolery wymagaj� uwierzytlniania i maj� odpowiedni claim tu api1
            });
        }
    }
}
