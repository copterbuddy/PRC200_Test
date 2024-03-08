using Entitiy.AI2IS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository;

public class ExportMobileAppNotiRepository : IExportMobileAppNotiRepository
{
    public ExportMobileAppNotiRepository()
    {
        
    }

    public async Task<List<MobileAppNotificationModel>> GetMobileAppNotification(string serviceId)
    {
        return new List<MobileAppNotificationModel>()
        {
            new MobileAppNotificationModel{ }
        };
    }

    public async Task<ActiveResultModel> GetServiceStatus(string serviceId)
    {
        return new ActiveResultModel(){ CurrentStatus = "Idle" };
    }

    public async Task<bool> LogStatus(DateTime now, string serviceId, string batchIsProcessing)
    {
        return true;
    }

    public async Task<bool> SetCurrentStatus(string serviceId, string v)
    {
        return true;
    }
}
