using System.Diagnostics;
using System.Dynamic;
using NewLibre;
using SQLitePCL;
namespace NlSysInfo.Tests;

public class DbTest
{
    [Fact]
    public void CreateDb(){
        ProcInfoContext pic = new();
        
    }

    [Fact]
    public void AddOneRecord(){
        ProcInfo pi;
        if (File.Exists("/usr/bin/bash")){
           pi = new ("linux-1", "/usr/bin/bash", 1);
        }
        else{
            pi = new ("macOS-1","/bin/zsh",2);
        }
        ProcInfoContext pic = new();
        pic.Add(pi);
        pic.SaveChanges();
    }

    [Fact]
    public void AddWithHash(){
        ProcInfo pi;
        if (File.Exists("/usr/bin/bash")){
           pi = new ("linux-1", "/usr/bin/bash", 1);
        }
        else{
            pi = new ("macOS-1","/bin/zsh",2);
        }
        ProcInfoContext pic = new();
        pi.GenSha256Hash();
        pic.Add(pi);
        pic.SaveChanges();
    }


    [Fact]
    public void FileDoesntExistEx(){
        
        Action act = () => new ProcInfo("test-proc", "/usr/bin/fakefile", 1);
        FileNotFoundException exception = Assert.Throws<FileNotFoundException>(act);
        
    }

    [Fact]
    public void BadPids(){
        SnapshotService snapsvc = new();
        snapsvc.SaveAllProcs(new int[]{1,2,3,10406,10727});
    }

    [Fact]
    public void SaveAllProcs(){
        
        Process [] allProcs = Process.GetProcesses();
        List<int> allPids = new();
        bool isAdded = false;
        HashSet<string> nameTrack = new ();
        for (int idx = 0; idx < allProcs.Length;idx++){
            var name = allProcs[idx].ProcessName.ToLower();
            name.Trim();
            if (!String.IsNullOrEmpty(name)){
                var endIdx = name.IndexOf(' ');
                if (endIdx > 0){
                    name = name.Substring(0,endIdx);
                }
            }

            isAdded = nameTrack.Add(name);
            // if isAdded, it means that the process name was successfully
            // added to the hashset, which means it hasn't been added previously
            // which means we want to add it to our list of pids
            // This all insures that each proc name is only added once.
            // For our snapshots, we only want one of each unique process added.
            if (isAdded){
                Console.Write($"{allProcs[idx].Id} : ");
                allPids.Add(allProcs[idx].Id);
            }
        }
        Console.WriteLine();
        SnapshotService snapsvc = new();
        snapsvc.SaveAllProcs(allPids.ToArray());

        foreach (string s in nameTrack){
            Console.WriteLine(s);
        }
    }
}
