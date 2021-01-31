using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyPlanner.API.Data;
using StudyPlanner.API.Extensions;
using System.Text;

namespace StudyPlanner.API.Configuration
{
    public static class IdentityConfig
    {

        public static IServiceCollection AddIdentityConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
              configuration.GetConnectionString("StudyPlannerContext")));
            
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            { 
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddErrorDescriber<IdentityMensagensPortugues>()
            .AddDefaultTokenProviders();

            var appSettingSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);

            var appSettings = appSettingSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);


            //services.AddIdentityCore<IdentityUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            return services;
        }
    }
}
