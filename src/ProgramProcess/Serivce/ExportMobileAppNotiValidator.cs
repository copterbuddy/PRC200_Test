using ApplicationCore.Constants.StringValues;
using ApplicationCore.Extensions;
using ApplicationCore.IService;
using Entitiy.AI2IS.Models;
using Infrastructure.Repository;
using ProgramProcess.Configurations;

namespace ProgramProcess.Serivce;

public class ExportMobileAppNotiValidator : IExportMobileAppNotiValidator
{

    private readonly IExportMobileAppNotiRepository _exportMobileAppNotiRepository;
    private readonly ConfigurationContext _config;
    public ExportMobileAppNotiValidator(IExportMobileAppNotiRepository exportMobileAppNotiRepository, ConfigurationContext config)
    {
        _exportMobileAppNotiRepository = exportMobileAppNotiRepository;
        _config = config;
    }

    public async Task<MobileAppNotiTaskValidatorModel> ValidateTask()
    {
        MobileAppNotiTaskValidatorModel result = new();
        string serviceId = _config.ServiceId;
        List<MobileAppNotificationModel> mobileAppNotifications = new();

        try
        {

            ActiveResultModel resultServiceStatus = await _exportMobileAppNotiRepository.GetServiceStatus(serviceId);

            LogHelper.LogInfo($"Service status = {resultServiceStatus?.CurrentStatus}");

            if (resultServiceStatus?.IsBatchIdle == false)
            {
                LogHelper.LogInfo(CustomMessage.BatchIsProcessing);
                await _exportMobileAppNotiRepository.LogStatus(DateTime.Now, serviceId, CustomMessage.BatchIsProcessing);

                return result.CannotGenerate();
            }

            LogHelper.LogInfo($"Get service status success");

            mobileAppNotifications = await _exportMobileAppNotiRepository.GetMobileAppNotification(serviceId);

            if (mobileAppNotifications?.Count < 1)
            {
                LogHelper.LogInfo($"Notification data not found.");
                await _exportMobileAppNotiRepository.LogStatus(DateTime.Now, serviceId, CustomMessage.NotFoundData);
                await _exportMobileAppNotiRepository.SetCurrentStatus(serviceId, nameof(CurrentStatus.Status.Idle));
                await _exportMobileAppNotiRepository.LogStatus(DateTime.Now, serviceId, nameof(CurrentStatus.Status.Idle));
                return result.CannotGenerate();
            }
        }
        catch (Exception ex)
        {

        }

        return result.Success(mobileAppNotifications ?? new());
    }
}
