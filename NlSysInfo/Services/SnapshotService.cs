using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Enumeration;

namespace NewLibre;
public class SnapshotService{
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

                var procName = ValidateProcName(p.ProcessName, filename);

                Snapshot ss = new (procName, filename);
                ss.Created = snapshotCreated;
                ss.FileHash = Utils.GenSha256(filename);
                Console.WriteLine($"Got pname: {ss.Name}");
                SnapshotContext sc = new();
                try{
                    sc.Add(ss);
                    sc.SaveChanges();
                }
                catch(Exception ex){
                    Console.WriteLine($"########--  {ex.Message} : {ex.InnerException?.Message}    --##########");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } // swallowing failures, considering that pid was bad
            
        }
        return true;
    }

    private string ValidateProcName(string name, string filename){
        if (String.IsNullOrEmpty(name)){
            if (!String.IsNullOrEmpty(filename)){
                var beginIdx = filename.LastIndexOf(Path.DirectorySeparatorChar);
                if (beginIdx > -1){
                    // +1 in next line is so it doesn't include dirsepchar
                    name = filename.Substring(beginIdx+1,filename.Length - beginIdx - 1);
                }
            }
        }
        return name;
    }
}