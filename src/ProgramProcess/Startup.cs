﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramProcess.Configurations;
using ApplicationCore.Utilities;
using ApplicationCore.Constants;
using Entitiy.AI2IS;
using ApplicationCore.Serivce;
using ApplicationCore.IService;
using Infrastructure.Repository;
using ProgramProcess.IService;
using ProgramProcess.Serivce;
using ApplicationCore.ISerivce;

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
        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<IExportMobileAppNotiTask>();
        await service!.RunAsync();
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

        services.AddScoped<IExportMobileAppNotiTask, ExportMobileAppNotiTask>();

        services.AddScoped<IExportMobileAppNotiValidator, ExportMobileAppNotiValidator>();

        services.AddScoped<IExportMobileAppNotiRepository, ExportMobileAppNotiRepository>();

        services.AddScoped<ICsvService, CsvService>();

    }

    public IConfiguration BuildConfiguration()
    {
        builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        string environmentName = builder?.Build()?.GetValue<string>("Environments") ?? string.Empty;

        builder = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

        return builder!.Build();
    }
}
