using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Services;
using Models.Repositories;
using DinkToPdf.Contracts;
using DinkToPdf;
using WebApi.Utility;
using Microsoft.Extensions.FileProviders;
using System.IO;
using WebApi.Helpers;

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

            services.AddCors(o => o.AddPolicy("Policy", builder =>
            {
                builder.SetIsOriginAllowed((host) => true)
                        .WithOrigins("https://internship2021.mss.ba")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllers();
            var tokenkey = Configuration.GetSection("AppSettings").GetSection("Secret").Value;
            var key = Encoding.ASCII.GetBytes(tokenkey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IJWTAuthenticationManager,JWTAuthenticationManager>();
            services.AddTransient<IAssetsRepository,AssetsRepository>();
            services.AddTransient<ILocationRepository,LocationRepository>();
            services.AddTransient<IDepartmentRepository,DepartmentRepository>();
            services.AddTransient<IAssetEmployeeRepository,AssetEmployeeRepository>();
            services.AddTransient<IAssetTypeRepository,AssetTypeRepository>();
            services.AddTransient<IAssetCategoryRepository, AssetCategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            services.AddTransient<IVendorRepository, VendorRepository>();
            services.AddTransient<IEmployeeRepository,EmployeeRepository>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IAssetsService,AssetsService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDatabaseService, DatabaseService>();
            services.AddTransient<IReportsService, ReportsService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ITemplateGenerator, TemplateGenerator>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


            services.AddMvc();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Exports")),
                RequestPath = "/Files"
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Policy");

            app.UseAuthentication();
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Awesome API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Awesome API V1");
                });
            }
        }
    }
}
