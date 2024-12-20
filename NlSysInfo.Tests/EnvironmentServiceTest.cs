
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
        
        es.StartProcess("/opt/microsoft/msedge/msedge");

    }

    [Fact]
    public void StartNewProcTestWithURL(){
        EnvironmentService es = new();
        
        es.StartProcess("/opt/microsoft/msedge/msedge","https://stackoverflow.com/questions/47658250/return-jsx-from-function");

    }
}