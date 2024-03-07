using ProgramProcess.Infrastructure;

namespace ProgramProcess;

internal static class Program
{
    private static Mutex mutex = new(true, "export-estatement-app-noti");
    [STAThread]
    public static void Main(string[] args)
    {
        LogHelper.LogInfo("Application started. (To terminate this app press Ctrl+C)");

        try
        {
            if (mutex.WaitOne(TimeSpan.Zero, true) == false)
            {
                LogHelper.LogInfo("Another instant is running");
                return;
            }

            try
            {
                Startup app = new();
                app.StartAsync().Wait();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
        catch (Exception ex)
        {
            LogHelper.LogError($"Stopped application because of exception : \r\n{ex.Message}");
            throw;
        }
        finally
        {
            LogHelper.LogInfo("Application stopped.");
        }
    }
}