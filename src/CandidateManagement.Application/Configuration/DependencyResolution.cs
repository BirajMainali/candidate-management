using CandidateManagement.Application.Services;
using CandidateManagement.Application.Services.Interfaces;
using CandidateManagement.Infrastructure.Repositories.Candidates;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateManagement.Application.Configuration;

public static class DependencyResolution
{
    public static IServiceCollection UseApplication(this IServiceCollection services)
    {
        services.AddScoped<ICandidateRepository, CandidateRepository>();
        services.AddScoped<ICandidateService, CandidateService>();
        return services;
    }
}