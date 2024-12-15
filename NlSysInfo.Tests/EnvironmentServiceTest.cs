
using System.Text.Json;
using NewLibre;

namespace NlSysInfo.Tests;

public class EnvironmentServiceTest{

    [Fact]
    public void GetSpecialFoldersTest(){
        EnvironmentSerivce es = new();
        var retVal = es.GetSpecialFolders();
        Console.WriteLine(retVal);
        Assert.Equal("", retVal);
    }
}