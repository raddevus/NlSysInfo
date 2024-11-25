using System.Diagnostics;

namespace NewLibre;
public class ProcInfo{
    public Int32 Id{get;set;}
    public string Name{get;set;}
    public string Filename{get;set;}
    public int ProcId{get;set;}

    public string FileHash{get;set;}

    public long FileSize{get;set;}
    
    public String? Created{get;set;}

    public ProcInfo(String name, String filename, int procId)
    {
        name = name.Trim();
        if (!String.IsNullOrEmpty(name)){
            var endIdx = name.IndexOf(' ');
            if (endIdx > 0){
                name = name.Substring(0,endIdx);
            }
        }
        Name = name;
        Filename = filename;
        ProcId = procId;
        Created = DateTime.Now.ToString();
        try{
            if (Filename != null && Filename != String.Empty){
                FileInfo fi = new FileInfo(Filename);
                FileSize = fi.Length;
            }
        }
        catch (Exception ex){
            Console.WriteLine($"FAIL! : {ex.GetType().ToString()}:{ex.Message}");
            throw ex;
        }
    }

    public long GetWorkingSet(){
        // ### From Copilot  ###
        // what is working set memory?
        // Working set memory refers to the amount of physical memory (RAM) 
        // that a process is currently using and is actively being used by 
        // the process. This includes both the private memory allocated by 
        // the process and the memory shared with other processes.
        var proc = Process.GetProcessById(ProcId);
        return proc.WorkingSet64;

    }
    
    public string GenSha256Hash(){
        if (String.IsNullOrEmpty(Filename)){
            return String.Empty;
        }
        FileHash = GetHashFromFileBytes(Filename);
        return FileHash;
    }

    private string GetHashFromFileBytes(string targetFile){
        return Utils.GenSha256(targetFile);
    }

    public static Process GetProcById(int pid){
        return Process.GetProcessById(pid);
    }
}