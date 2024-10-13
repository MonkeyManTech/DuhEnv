namespace DuhEnv;

public class DuhEnvConfigurator(string fileName)
{
    internal bool IncludeEmptyValues;
    internal string EnvFileName = fileName;

    public DuhEnvConfigurator() : this(".env")
    { }

    public DuhEnvConfigurator WithEmptyValues()
    { 
        IncludeEmptyValues = true;
        return this;
    }
    
    public DuhEnvConfigurator WithFileName(string fileName)
    {
        EnvFileName = fileName;
        return this;
    }
    
}