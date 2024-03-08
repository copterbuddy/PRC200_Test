using ProgramProcess;
using ProgramProcess.Extensions;
using ProgramProcessTest.Extensions.Model;

namespace ProgramProcessTest;

public class ProgramTest
{
    public ProgramTest()
    {
        
    }

    [Fact]
    public void Main_ShouldLogInfoWhenApplicationStarted()
    {
        // Act
        var args = new string[] { };
        var expected1 = $"Application started. (To terminate this app press Ctrl+C)";
        var expected2 = $"Application stopped.";
        using ConsoleOutput consoleOutput = new ConsoleOutput();

        // Act
        Program.Main(args);

        // Assert
        Assert.Contains(expected1, consoleOutput.GetOutput());
        Assert.Contains(expected2, consoleOutput.GetOutput());
    }
}
