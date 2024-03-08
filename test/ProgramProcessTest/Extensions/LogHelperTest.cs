using ProgramProcess.Extensions;
using ProgramProcessTest.Extensions.Model;

namespace ProgramProcessTest.Extensions;

public class LogHelperTest
{
    [Fact]
    public void LogInfo_ShouldWriteInfoLog()
    {
        // Arrange
        var logDetails = "Test log details";
        var expected1 = $"{DateTime.Now.ToString("yyyyMMdd")}";
        var expected2 = $"[INFO] >> {logDetails}";

        // Act
        using ConsoleOutput consoleOutput = new ConsoleOutput();
        LogHelper.LogInfo(logDetails);

        // Assert
        Assert.Contains(expected1, consoleOutput.GetOutput());
        Assert.Contains(expected2, consoleOutput.GetOutput());
    }

    [Fact]
    public void LogDebug_ShouldWriteDebugLog()
    {
        // Arrange
        var logDetails = "Test log details";
        var expected1 = $"{DateTime.Now.ToString("yyyyMMdd")}";
        var expected2 = $"[DEBUG] >> {logDetails}";


        // Act
        using ConsoleOutput consoleOutput = new ConsoleOutput();
        LogHelper.LogDebug(logDetails);

        // Assert
        Assert.Contains(expected1, consoleOutput.GetOutput());
        Assert.Contains(expected2, consoleOutput.GetOutput());
    }

    [Fact]
    public void LogError_ShouldWriteErrorLog()
    {
        // Arrange
        var logDetails = "Test log details";
        var expected1 = $"{DateTime.Now.ToString("yyyyMMdd")}";
        var expected2 = $"[ERROR] >> {logDetails}";


        // Act
        var consoleOutput = new ConsoleOutput();
        LogHelper.LogError(logDetails);

        // Assert
        Assert.Contains(expected1, consoleOutput.GetOutput());
        Assert.Contains(expected2, consoleOutput.GetOutput());
        
    }
}
