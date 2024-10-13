using System;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace DuhEnv;

public class SearchAssemblyCatalog
{
    private static readonly string DuhEnvAssemblyName; 
    
    private readonly DependencyContext _dependencyContext;

    static SearchAssemblyCatalog()
    {
        DuhEnvAssemblyName = typeof(DuhEnvExtensions).Assembly.GetName().Name;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SearchAssemblyCatalog"/> class,
    /// using <see cref="Assembly.GetEntryAssembly()"/>.
    /// </summary>
    public SearchAssemblyCatalog()
        : this(Assembly.GetEntryAssembly())
    {
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="SearchAssemblyCatalog"/> class,
    /// using <paramref name="entryAssembly"/>.
    /// </summary>
    public SearchAssemblyCatalog(Assembly entryAssembly)
    {
        _dependencyContext = DependencyContext.Load(entryAssembly);
    }
    
    private static Assembly SafeLoadAssembly(AssemblyName assemblyName)
    {
        try
        {
            return Assembly.Load(assemblyName);
        }
        catch (Exception)
        {
            return null;
        }
    }
}