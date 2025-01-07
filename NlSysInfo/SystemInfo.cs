using System.Diagnostics;
using System.Text.Json;
namespace NewLibre;

public class SystemInfo
{

    // The class to handle the management of executble processes.
    public string GetAllProcNames(){
        Process [] allProcs = Process.GetProcesses();
        List<object> sl = new List<object>();
        
        foreach (Process p in allProcs)
        {
            var stopChar = p.ProcessName.IndexOf(" ");
            if (stopChar < 1){
                stopChar = p.ProcessName.Length;
            }
            sl.Add(new {procName=$"{p.ProcessName.Substring(0,stopChar)}",pid=p.Id});
        }
        // sl.Sort((pi1, pi2) => pi1.procName.CompareTo( pi2.ProcName));
        return JsonSerializer.Serialize(sl);
    }

    public List<ProcInfo> GetAllProcesses(){
        Process [] allProcs = Process.GetProcesses();
        List<ProcInfo> allProcInfo = new List<ProcInfo>();
        foreach (Process p in allProcs)
        {
            var stopChar = p.ProcessName.IndexOf(" ");
            if (stopChar < 1){
                stopChar = p.ProcessName.Length;
            }
            try{
                allProcInfo.Add(new ProcInfo(p.ProcessName.Substring(0,stopChar), p.MainModule?.FileName ?? "", p.Id));
            }
            catch(Exception ex){
                Console.WriteLine($"Couldn't access process to get module. {ex.Message}");
            }
        }
        allProcInfo.Sort((pi1, pi2) => pi1.Name.CompareTo( pi2.Name));
        return allProcInfo;
    }

    public string GetAllProcessesAsJson(){
        Process [] allProcs = Process.GetProcesses();
        List<ProcInfo> allProcInfo = new List<ProcInfo>();
        foreach (Process p in allProcs)
        {
            var stopChar = p.ProcessName.IndexOf(" ");
            if (stopChar < 1){
                stopChar = p.ProcessName.Length;
            }
            try{
                allProcInfo.Add(new ProcInfo(p.ProcessName.Substring(0,stopChar), p.MainModule?.FileName ?? "", p.Id));
            }
            catch(Exception ex){
                Console.WriteLine($"Couldn't access process to get module. {ex.Message}");
            }
        }
        allProcInfo.Sort((pi1, pi2) => pi1.Name.CompareTo( pi2.Name));
        return JsonSerializer.Serialize(allProcInfo);
    }

    public string GetAllProcModules(int pid){
        // Get all the modules that a specific process loads
        Process [] allProcs = Process.GetProcesses();
        List<object> modulesResult = new ();
        var targetProcess = allProcs.First(p => p.Id == pid);
        long totalMemSize = 0;
        // Protecting in case a bad pid is sent in
        if (targetProcess != null){
            ProcessModuleCollection allModules = targetProcess.Modules;
            foreach (ProcessModule pm in allModules){
                Console.WriteLine($"{pm.ModuleName} : {pm.FileName} : {pm.ModuleMemorySize}");
                modulesResult.Add(new {moduleName=pm.ModuleName, fileName=pm.FileName,  memorySize=pm.ModuleMemorySize});
                totalMemSize += pm.ModuleMemorySize;
            }
        }
        var outResult = new {totalMemSize=totalMemSize,modules=modulesResult};
        Console.WriteLine($"Modules take up {totalMemSize} bytes of memory.");
        return JsonSerializer.Serialize(outResult);
    }

    public void DisplayMainWindowTitle(int procId){
        Process [] allProcs = Process.GetProcesses();
        foreach (Process p in allProcs){
            if (p.Id == procId){
                Console.WriteLine("### GOT THE PROC #####!");
                try{
                    p.Refresh();
                    Console.WriteLine($"handle- {p.MainWindowHandle} : title- {p.MainWindowTitle} : handleCount - {p.HandleCount}");
                    Console.WriteLine($"{p.StartTime}");
                
                }
                catch (Exception ex){
                    Console.WriteLine($"Failed: {ex.Message}");
                }
            }
        }
    }
}

