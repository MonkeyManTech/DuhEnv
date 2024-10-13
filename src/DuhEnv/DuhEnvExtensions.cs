namespace DuhEnv;

// <summary>
/// Adds DuhEnvExtensions to the specified <see cref="IServiceCollection"/>.
/// </summary>
/// <param name="services">The <see cref="IServiceCollection"/> to add DotEnv to.</param>
/// <param name="assemblyCatalog">Optional <see cref="DependencyContextAssemblyCatalog"/> assemblies containing .env file. If not provided, the default catalog of assemblies is added, which includes Assembly.GetEntryAssembly.</param>
/// <param name="configurator">Optional <see cref="DotEnvConfigurator"/> to configure DotEnv functionality.</param>
public static class DuhEnvExtensions
{
    public static IServiceCollection AddDuhEnv(this IServiceCollection services)
    {
        
    }
    
    
    public static void Load(Action<DotEnvConfigurator>? configurator)
    {
        var filePath = envFilePath ?? Path.Combine(Directory.GetCurrentDirectory(), ".env");
        
        if(!File.Exists(filePath)) return;

        foreach (var line in File.ReadAllLines(filePath))
        {
            var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) continue;
            
            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}