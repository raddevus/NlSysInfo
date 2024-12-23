
using System.Text.Json;
using NewLibre;

namespace NlSysInfo.Tests;

public class EnvironmentServiceTest{

    [Fact]
    public void GetSpecialFoldersTest(){
        EnvironmentService es = new();
        var retVal = es.GetSpecialFolders();
        Console.WriteLine($"{retVal}");
        Assert.NotEqual("", retVal);
    }

    [Fact]
    public void GetAllEnvVarsTest(){
        EnvironmentService es = new();
        var retVal = es.GetAllEnvVars();
        Console.WriteLine($"{retVal}");
        Assert.NotEqual("", retVal);
    }

    [Fact]
    public void StartNewProcTestNoArgs(){
        EnvironmentService es = new();
        
        var pid = es.StartProcess("/opt/microsoft/msedge/msedge");
        if (pid == -1){
            pid = es.StartProcess("/Applications/Microsoft Edge.app/Contents/MacOS/Microsoft Edge");
        }
        // System.Threading.Thread.Sleep(2000);
        // SnapshotService ss = new();
        // ss.KillProcess(pid);

    }

    [Fact]
    public void StartNewProcTestWithURL(){
        EnvironmentService es = new();
        
        var pid = es.StartProcess("/opt/microsoft/msedge/msedge","https://stackoverflow.com/questions/47658250/return-jsx-from-function");
        if (pid == -1){
            pid = es.StartProcess("/Applications/Microsoft Edge.app/Contents/MacOS/Microsoft Edge","https://newlibre.com");
        }
        // System.Threading.Thread.Sleep(2000);
        // SnapshotService ss = new();
        // ss.KillProcess(pid);
        
    }
}