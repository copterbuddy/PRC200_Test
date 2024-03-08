using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramProcess.Extensions;
using Microsoft.Extensions.Options;
using ProgramProcess.Configurations;
using ApplicationCore.Utilities;
using ApplicationCore.Constants;
using Entitiy.AI2IS;
using ApplicationCore.Serivce;
using Infrastructure;

namespace ProgramProcess;

public class Startup
{
    private readonly IServiceCollection services;
    private IConfigurationBuilder builder;

    public Startup()
    {
        services = new ServiceCollection();
        ConfigureServices();
    }

    public async Task StartAsync()
    {
        return;
    }

    public void ConfigureServices()
    {
        IConfiguration config = BuildConfiguration();
        services.AddSingleton(config);

        var configuration = new ConfigurationContext(config);
        services.AddTransient<ConfigurationContext>();

        string connectionString = configuration.AI2ISConnectionString;
        connectionString = RijndaelEncryption.Decrypt(connectionString, RijnDaelKey.Key);

        services.AddSingleton(option => new AI2ISOptionBuilder(connectionString, 30));

        services.AddScoped<ExportMobileAppNotiTask>();

        services.AddScoped<IExportMobileAppNotiRepository, ExportMobileAppNotiRepository>();
    }

    public IConfiguration BuildConfiguration()
    {
        builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        string environmentName = builder?.Build()?.GetValue<string>("Environments") ?? string.Empty;

        if (string.IsNullOrEmpty(environmentName))
        {
            builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true);
        }

        return builder!.Build();
    }
}
