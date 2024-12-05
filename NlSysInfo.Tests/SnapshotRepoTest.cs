namespace NlSysInfo.Tests;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using NewLibre;

public class SnapshotRepoTest{
    [Fact]
    public void GetProcInfo(){
        SnapshotRepository sr = new SnapshotRepository();
        ProcInfo? pi = JsonSerializer.Deserialize<ProcInfo>(sr.GetMatchingSnapshots());
        Console.WriteLine($"{pi.Created} {pi.Name} {pi.Filename}");
        
    }
}