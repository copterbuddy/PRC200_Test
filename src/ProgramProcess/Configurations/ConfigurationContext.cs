using Microsoft.Extensions.Configuration;

namespace ProgramProcess.Configurations;

public class ConfigurationContext
{
    private readonly IConfiguration _configuration;
    public ConfigurationContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Environments => _configuration.GetValue<string>(nameof(Environments));
    public bool IsDevelopment => (Environments ?? "Development") == "Development";
    public string AI2ISConnectionString => _configuration.GetValue<string>(nameof(AI2ISConnectionString));
    public string ServiceId => _configuration.GetValue<string>(nameof(ServiceId));
}
