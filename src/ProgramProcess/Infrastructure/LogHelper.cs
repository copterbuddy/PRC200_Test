using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramProcess.Infrastructure;

public static class LogHelper
{
    public static void LogInfo(string logDetails)
    {
        Console.WriteLine($"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss.SSS")}[INFO] >> {logDetails}");
    }

    public static void LogDebug(string logDetails)
    {
        Console.WriteLine($"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss.SSS")}[DEBUG] >> {logDetails}");
    }

    public static void LogError(string logDetails)
    {
        Console.WriteLine($"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss.SSS")}[ERROR] >> {logDetails}");
    }
}
