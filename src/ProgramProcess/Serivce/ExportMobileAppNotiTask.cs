using ApplicationCore.IService;
using Infrastructure;
using ProgramProcess.Configurations;

namespace ApplicationCore.Serivce;

public class ExportMobileAppNotiTask : IExportMobileAppNotiTask
{
    public const string TaskName = "ExportMobileAppNoti";

    private readonly IExportMobileAppNotiRepository _exportMobileAppNotiRepository;
    private readonly ConfigurationContext _config;
    public ExportMobileAppNotiTask(IExportMobileAppNotiRepository exportMobileAppNotiRepository,ConfigurationContext configuration)
    {
        _exportMobileAppNotiRepository = exportMobileAppNotiRepository;
        _config = configuration;
    }
    public async Task RunAsync()
    {

    }
}
