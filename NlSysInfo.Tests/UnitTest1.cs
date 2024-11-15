using NewLibre;
namespace NlSysInfo.Tests;

public class UnitTest1
{
    [Fact]
    public void TestProcNames()
    {
        SystemInfo si = new();
        List<string> allNames = si.GetAllProcNames();
        foreach (string s in allNames){
            Console.Write($"{s}, ");
        }
        // Assert.Contains("teams:5275",allNames);
    }
}