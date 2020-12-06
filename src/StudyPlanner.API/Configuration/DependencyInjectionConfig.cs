using Microsoft.Extensions.DependencyInjection;
using StudyPlanner.Business.Interfaces;
using StudyPlanner.Business.Notificacoes;
using StudyPlanner.Business.Services;
using StudyPlanner.Data.Context;
using StudyPlanner.Data.Repository;

namespace StudyPlanner.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies (this IServiceCollection services)
        {
            services.AddScoped<StudyPlannerContext>();
            services.AddScoped<IConhecimentoRepository, ConhecimentoRepository>();
            services.AddScoped<IConhecimentoServices, ConhecimentoServices>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }

    }
}
