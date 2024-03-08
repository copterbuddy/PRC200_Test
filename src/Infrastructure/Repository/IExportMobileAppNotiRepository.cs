using Entitiy.AI2IS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository;

public interface IExportMobileAppNotiRepository
{
    Task<List<MobileAppNotificationModel>> GetMobileAppNotification(string serviceId);
    Task<ActiveResultModel> GetServiceStatus(string serviceId);
    Task<bool> LogStatus(DateTime now, string serviceId, string batchIsProcessing);
    Task<bool> SetCurrentStatus(string serviceId, string v);
}
