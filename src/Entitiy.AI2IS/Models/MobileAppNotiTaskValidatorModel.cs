using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy.AI2IS.Models;

public class MobileAppNotiTaskValidatorModel
{
    public bool IsValid { get; set; } = false;
    public List<MobileAppNotificationModel> MobileAppNotificationModels = new List<MobileAppNotificationModel>();

    public MobileAppNotiTaskValidatorModel Success(List<MobileAppNotificationModel> notiList)
    {
        return new MobileAppNotiTaskValidatorModel
        {
            IsValid = true,
            MobileAppNotificationModels = notiList,
        };
    }

    public MobileAppNotiTaskValidatorModel CannotGenerate()
    {
        return new MobileAppNotiTaskValidatorModel
        {
            IsValid = false,
            MobileAppNotificationModels = new(),
        };
    }
}
