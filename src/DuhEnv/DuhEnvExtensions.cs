namespace DuhEnv;

using System;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Adds DuhEnvExtensions to the specified <see cref="IServiceCollection"/>.
/// </summary>
/// <param name="services">The <see cref="IServiceCollection"/> to add DuhEnv to.</param>
/// <param name="configurator">Optional <see cref="DuhEnvConfigurator"/> to configure DuhEnv functionality.</param>
public static class DuhEnvExtensions
{
    public static IServiceCollection AddDuhEnv(this IServiceCollection services,
        Action<DuhEnvConfigurator> configurator = null)
    {
        var config = new DuhEnvConfigurator();
        configurator?.Invoke(config);
        
        WireUpDuhEnv(services, config);

        return services;
    }
    
    private static void WireUpDuhEnv(this IServiceCollection services, DuhEnvConfigurator configurator)
    {
        services.AddSingleton(configurator);
    }
}