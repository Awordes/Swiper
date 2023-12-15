using Microsoft.Extensions.DependencyInjection;
using Swiper.Simulator.API;
using Swiper.Simulator.Services;

namespace Swiper.Simulator;

public static class DependencyInjection
{
    public static IServiceCollection AddSimulator(this IServiceCollection services)
    {
        services.AddTransient<ISimulatorService, SimulatorService>();
        return services;
    }
}
