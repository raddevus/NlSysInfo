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
                FileHash = GetHashFromFileBytes(FileName);
            }
        }
        catch (Exception ex){
            // leave the FileHash blank if you can't read the file
            Console.WriteLine($"FAIL! : {ex.Message}");
        }
    }

    private string GetHashFromFileBytes(string targetFile){
        return Utils.GenSha256(targetFile);
    }
}