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
            FileInfo fi = new FileInfo(FileName);
            FileSize = fi.Length;
            
            FileHash = GetHashFromFileBytes(FileName, (int)fi.Length);
        }
        catch (Exception ex){
            // leave the FileHash blank if you can't read the file
            Console.WriteLine($"FAIL! : {ex.Message}");
        }
    }

    private string GetHashFromFileBytes(string targetFile, int byteLength){
        var reader = new FileStream(targetFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

         char[] allBytes = new char[byteLength];
        using (FileStream fs = new FileStream(targetFile, 
                                      FileMode.Open, 
                                      FileAccess.Read,    
                                      FileShare.ReadWrite))
        {
            using (StreamReader sr = new StreamReader(fs))
            {
                sr.Read(allBytes,0,byteLength);
            }
        }
        
        return Utils.GenSha256(System.Text.Encoding.UTF8.GetBytes(allBytes));
        //return Utils.GenSha256(targetFile);
        
    }
}