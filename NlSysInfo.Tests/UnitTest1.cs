using NewLibre;
namespace NlSysInfo.Tests;

public class UnitTest1
{
    [Fact]
    public void TestProcNames()
    {
        SystemInfo si = new();
        var allProcNames = si.GetAllProcNames();
        Console.WriteLine($"Got {allProcNames.Count()} procs. \n{allProcNames}");
        Assert.NotEqual("", allProcNames);
    }

    [Fact]
    public void GetAllProcsAsJson(){
        SystemInfo si = new();
        var allProcs = si.GetAllProcessesAsJson();
        Console.WriteLine(allProcs);
        Assert.NotEqual("",allProcs);

    }

    [Fact]
    public void TestProcInfo(){
        SystemInfo si = new();
        List<ProcInfo> allPI = si.GetAllProcesses();
        foreach (ProcInfo p in allPI){
            Console.WriteLine($"{p.Name} : {p.ProcId} : {p.Filename} : {p.FileSize:N0} : {p.FileHash}");
        }
    }

    [Fact]
    public void TestGenHash(){
        SystemInfo si = new();
        List<ProcInfo> allPI = si.GetAllProcesses();
        foreach (ProcInfo p in allPI.Where(pi => pi.Filename != String.Empty)){
            Console.WriteLine($"## GenHash ## {p.Name} : {p.GenSha256Hash()}");
        }
    }
    
    [Fact]
    public void GetWindowTitle(){
        SystemInfo si = new();
        si.DisplayMainWindowTitle(18634);
    }

    [Fact]
    public void GetProcModules(){
        SystemInfo si = new();
        
        string jsonresult = String.Empty;
        jsonresult = si.GetAllProcModules(19291);

        Console.WriteLine($"{jsonresult}");

    }
}