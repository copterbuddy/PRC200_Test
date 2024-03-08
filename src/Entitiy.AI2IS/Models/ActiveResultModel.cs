using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy.AI2IS.Models;

public partial class ActiveResultModel
{
    public string CurrentStatus { get; set; } = string.Empty;
    public bool IsBatchIdle => CurrentStatus == "Idle";
}
