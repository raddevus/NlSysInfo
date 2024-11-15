namespace NewLibre;
public class ProcInfo{
    public string Name{get;set;}
    public string FileName{get;set;}
    public int ProcId{get;set;}

    public ProcInfo(String name, String filename, int procId)
    {
        Name = name;
        FileName = filename;
        ProcId = procId;
    }
}