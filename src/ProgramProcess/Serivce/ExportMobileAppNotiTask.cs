using ApplicationCore.Constants.StringValues;
using ApplicationCore.Extensions;
using ApplicationCore.IService;
using Infrastructure.Repository;
using ProgramProcess.Configurations;
using ProgramProcess.IService;

namespace ApplicationCore.Serivce;

public class ExportMobileAppNotiTask : IExportMobileAppNotiTask
{
    public const string TaskName = "ExportMobileAppNoti";

    private readonly IExportMobileAppNotiRepository _exportMobileAppNotiRepository;
    private readonly ConfigurationContext _config;
    private readonly IExportMobileAppNotiValidator _taskValidator;

    public ExportMobileAppNotiTask(IExportMobileAppNotiRepository exportMobileAppNotiRepository, IExportMobileAppNotiValidator taskValidator, ConfigurationContext config)
    {
        _exportMobileAppNotiRepository = exportMobileAppNotiRepository;
        _taskValidator = taskValidator;
        _config = config;
    }
    public async Task RunAsync()
    {
        LogHelper.LogInfo("Start application");
        LogHelper.LogInfo("Get service status");

        string serviceId = _config?.ServiceId ?? "Undefined";

        var validator = await _taskValidator.ValidateTask();
        if (validator?.IsValid is null or false)
        {
            return;
        }

    }
}
