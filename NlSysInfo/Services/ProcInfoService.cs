using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Enumeration;

namespace NewLibre;
public class ProcInfoService{
    public bool SaveProcInfo(){
        return true;
    }

    public bool SaveAllProcs(int [] allProcIds){
        var snapshotCreated = DateTime.Now.ToString();
        foreach (int pid in allProcIds){
            Console.WriteLine($"** Saving ProcId: {pid}");
            
            try {
                Process p = ProcInfo.GetProcById(pid);
                var filename = p.MainModule.FileName;
                Console.WriteLine($"** Got filename: {filename}");
                Snapshot ss = new (p.ProcessName, filename);
                ss.Created = snapshotCreated;
                ss.FileHash = Utils.GenSha256(filename);
                Console.WriteLine($"Got pname: {ss.Name}");
                SnapshotContext sc = new();
                sc.Add(ss);
                sc.SaveChanges();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } // swallowing failures, considering that pid was bad
            
        }
        return true;
    }
}