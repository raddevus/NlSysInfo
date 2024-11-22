using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Enumeration;

namespace NewLibre;
public class ProcInfoService{
    public bool SaveProcInfo(){
        return true;
    }

    public bool SaveAllProcs(int [] allProcIds){
        foreach (int pid in allProcIds){
            Console.WriteLine($"** Saving ProcId: {pid}");
            Process p = ProcInfo.GetProcById(pid);
            try {
                var filename = p.MainModule.FileName;
                Console.WriteLine($"** Got filename: {filename}");
                ProcInfo pi = new (p.ProcessName, filename,p.Id);
                Console.WriteLine($"Got pname: {pi.Name}");
                SnapshotContext sc = new();
                sc.Add(pi);
                sc.SaveChanges();
            }
            catch {} // swallowing failures, considering that pid was bad
            
        }
        return true;
    }
}