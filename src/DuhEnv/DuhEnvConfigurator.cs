namespace DuhEnv;

public class DotEnvConfigurator
{
    internal DotEnvConfigurator()
    {
        
    }

    internal bool ExcludeEmptyValues;

    public DotEnvConfigurator WithEmptyValues()
    {
        this.ExcludeEmptyValues = true;
        return this;
    }
}