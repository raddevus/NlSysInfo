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