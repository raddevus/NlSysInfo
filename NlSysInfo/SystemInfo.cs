﻿using System.Diagnostics;
namespace NewLibre;

public class SystemInfo
{

    // The class to handle the management of executble processes.
    public List<string> GetAllProcNames(){
        Process [] allProcs = Process.GetProcesses();
        List<string> sl = new List<string>();
        foreach (Process p in allProcs)
        {
            var stopChar = p.ProcessName.IndexOf(" ");
            if (stopChar < 1){
                stopChar = p.ProcessName.Length;
            }
            sl.Add($"{p.ProcessName.Substring(0,stopChar)}:{p.Id}");
        }
        sl.Sort();
        return sl;
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

    public List<string> GetAllProcModules(string targetProcName){
        // Get all the modules that a specific process loads
        Process [] allProcs = Process.GetProcesses();
        foreach (Process p in allProcs){
            if (p.ProcessName == targetProcName){
                ProcessModuleCollection allModules = p.Modules;
                foreach (ProcessModule pm in allModules){
                    Console.WriteLine(pm.ModuleName);
                }
            }
        }
        return new List<string>();
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

