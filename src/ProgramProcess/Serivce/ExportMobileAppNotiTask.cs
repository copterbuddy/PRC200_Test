using ApplicationCore.Constants.StringValues;
using ApplicationCore.Extensions;
using ApplicationCore.IService;
using Entitiy.AI2IS.Models;
using Infrastructure.Repository;
using ProgramProcess.Configurations;

namespace ApplicationCore.Serivce;

public class ExportMobileAppNotiTask : IExportMobileAppNotiTask
{
    public const string TaskName = "ExportMobileAppNoti";

    private readonly IExportMobileAppNotiRepository _exportMobileAppNotiRepository;
    private readonly ConfigurationContext _config;
    public ExportMobileAppNotiTask(IExportMobileAppNotiRepository exportMobileAppNotiRepository,ConfigurationContext config)
    {
        _exportMobileAppNotiRepository = exportMobileAppNotiRepository;
        _config = config;
    }
    public async Task RunAsync()
    {
        LogHelper.LogInfo("Start application");
        LogHelper.LogInfo("Get service status");

        string serviceId = "Undefined";

        try
        {
            serviceId = _config.ServiceId;
            ActiveResultModel resultServiceStatus = await _exportMobileAppNotiRepository.GetServiceStatus(serviceId);

            LogHelper.LogInfo($"Service status = {resultServiceStatus?.CurrentStatus}");

            if (resultServiceStatus?.IsBatchIdle == false)
            {
                LogHelper.LogInfo(CustomMessage.BatchIsProcessing);
                await _exportMobileAppNotiRepository.LogStatus(DateTime.Now, serviceId, CustomMessage.BatchIsProcessing);
                return;
            }

            LogHelper.LogInfo($"Get service status success");

            List<MobileAppNotificationModel> mobileAppNotifications = await _exportMobileAppNotiRepository.GetMobileAppNotification(serviceId);

            if (mobileAppNotifications?.Count < 1)
            {
                LogHelper.LogInfo($"Notification data not found.");
                await _exportMobileAppNotiRepository.LogStatus(DateTime.Now, serviceId, CustomMessage.NotFoundData);
                await _exportMobileAppNotiRepository.SetCurrentStatus(serviceId, nameof(CurrentStatus.Status.Idle));
                await _exportMobileAppNotiRepository.LogStatus(DateTime.Now, serviceId, nameof(CurrentStatus.Status.Idle));
                return;
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
}
