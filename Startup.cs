using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Mobile_Store.Commons;
using Mobile_Store.Data;
using Mobile_Store.Repositories;

namespace Mobile_Store
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
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<MobileStoreContext>(opt => opt.UseInMemoryDatabase("MobileStore"));

            services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            });

            services.AddTransient<PopulateDatabase>();
            services.AddScoped<IBrandsRepository, BrandsRepository>();
            services.AddScoped<IPhonesRepository, PhonesRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mobile Store",
                    Description = "Wandio Task Project",
                    Contact = new OpenApiContact
                    {
                        Name = "Toma Chkheidze",
                        Email = "tomachkheidze@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/tomachkheidze/"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath, true);
            });

            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PopulateDatabase populateDatabase)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSimulatedLatency(TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(1000));
            }

            //populate data
            populateDatabase.Seed().Wait();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mobile Store v1");
                options.DocumentTitle = "Mobile Store API";
                options.RoutePrefix = "api";
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
