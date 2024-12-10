namespace NlSysInfo.Tests;

using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using NewLibre;

public class SnapshotRepoTest{
    [Fact]
    public void GetProcInfo(){
        SnapshotRepository sr = new SnapshotRepository();
        string targetFileName = string.Empty;
        if (File.Exists("/usr/bin/bash")){
           targetFileName = "/usr/bin/bash";
        }
        else{
            targetFileName = "/bin/zsh";
        }

        List<ProcInfo> pi = JsonSerializer.Deserialize<List<ProcInfo>>(sr.GetMatchingSnapshotsByName(targetFileName));
        // print first and last 
        int lastIdx = pi.Count-1;
        if (lastIdx >= 0){
            Console.WriteLine($"{pi[0].Created} {pi[0].Name} {pi[0].Filename} {pi[0].FileDate ?? "empty string"}");
            Console.WriteLine($"{pi[lastIdx].Created} {pi[lastIdx].Name} {pi[lastIdx].Filename} {pi[lastIdx].FileDate ?? "empty string"}");
        }
    }

    [Fact]
    public  void GetProcInfoWithBadName(){
        SnapshotRepository sr = new SnapshotRepository();
        List<ProcInfo> pi = JsonSerializer.Deserialize<List<ProcInfo>>(sr.GetMatchingSnapshotsByName("fake-proc-name"));
                
        Assert.Equal(0,pi.Count);
    }

    [Fact]
    public void KillProcessTest(){
        // ### More to be done later, because
        // ### this test requires the valid procId of a process
        // ### running on the OS 
        // SnapshotService ss = new();
        // var osString = Environment.OSVersion.Platform.ToString().ToUpper();
        // if (osString.Contains("UNIX")){
        //     Process p = new ("/usr/bin/gnome-text-editor");

        // Console.WriteLine($"Success? {ss.KillProcess(14844)}");
    }
}