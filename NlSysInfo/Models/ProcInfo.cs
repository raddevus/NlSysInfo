using System.Diagnostics;

namespace NewLibre;
public class ProcInfo{
    public string Name{get;set;}
    public string FileName{get;set;}
    public int ProcId{get;set;}

    public string FileHash{get;set;}

    public long FileSize{get;set;}

    public ProcInfo(String name, String filename, int procId)
    {
        Name = name;
        FileName = filename;
        ProcId = procId;
        try{
            if (FileName != null && FileName != String.Empty){
                FileInfo fi = new FileInfo(FileName);
                FileSize = fi.Length;
            }
        }
        catch (Exception ex){
            Console.WriteLine($"FAIL! : {ex.Message}");
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
        if (String.IsNullOrEmpty(FileName)){
            return String.Empty;
        }
        return GetHashFromFileBytes(FileName);
    }

    private string GetHashFromFileBytes(string targetFile){
        return Utils.GenSha256(targetFile);
    }
}