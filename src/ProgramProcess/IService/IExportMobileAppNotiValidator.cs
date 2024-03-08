
using Entitiy.AI2IS.Models;

namespace ApplicationCore.IService;

public interface IExportMobileAppNotiValidator
{
    Task<MobileAppNotiTaskValidatorModel> ValidateTask();
}
