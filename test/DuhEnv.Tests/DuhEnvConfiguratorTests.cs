namespace DuhEnv.Tests;

public class DuhEnvConfiguratorTests
{
    [Fact]
    public void Should_not_add_empty_values()
    {
        var config = new DuhEnvConfigurator();
        config.WithEmptyValues();
        
        Assert.True(config.IncludeEmptyValues);
    }
    
    [Fact]
    public void Should_use_default_filename()
    {
        var config = new DuhEnvConfigurator();
        Assert.Equal(".env", config.EnvFileName);
    }
    
    [Fact]
    public void Should_use_custom_filename()
    {
        var config = new DuhEnvConfigurator();
        config.WithFileName("myEnvFile");
        Assert.Equal("myEnvFile", config.EnvFileName);
    }
}