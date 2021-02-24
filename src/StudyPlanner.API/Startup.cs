using AutoMapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudyPlanner.API.Configuration;
using StudyPlanner.API.Extensions;
using StudyPlanner.Data.Context;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StudyPlanner.API
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
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddDbContext<StudyPlannerContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("StudyPlannerContext")));

            services.AddIdentityConfiguration(Configuration);

            services.AddControllers();

            services.ResolveDependencies();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {

                options.AddPolicy("Development",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddSwaggerGen();

            services.AddHealthChecks().AddSqlServer(
                Configuration.GetConnectionString("StudyPlannerContext"), name: "BancoSQL");

            services.AddHealthChecksUI();
            
            services.ResolveDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Study Planner V1");
           });

            app.UseHealthChecks("/api/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options =>
            {                
                options.UIPath = "/api/hc-ui";
                options.ApiPath = "/super-api";
                options.UseRelativeApiPath = false;
                options.UseRelativeResourcesPath = false;
                options.UseRelativeWebhookPath = false;
            });       
        }
    }
}
