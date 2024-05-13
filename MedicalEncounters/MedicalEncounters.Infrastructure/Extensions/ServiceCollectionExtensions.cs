using MedicalEncounters.Application.Interfaces;
using MedicalEncounters.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalEncounters.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IMedicalEncounterRepository, MedicalEncounterRepository>();
        }
    }
}
