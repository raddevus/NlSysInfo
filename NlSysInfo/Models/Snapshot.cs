using System.Diagnostics;

namespace NewLibre;
public class Snapshot{
    public Int32 Id{get;set;}
    public string Name{get;set;}
    public string Filename{get;set;}

    public string? FileDate{get;set;}

    public string? Category{get;set;}
    
    public string FileHash{get;set;}

    public long FileSize{get;set;}
    
    public String? Created{get;set;}

    public Snapshot (String name){
         Name = name.Trim();

    }
    public Snapshot(String name, String filename)
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
        Created = DateTime.Now.ToString();
        try{
            if (Filename != null && Filename != String.Empty){
                if (File.Exists(Filename)){
                    FileInfo fi = new FileInfo(Filename);
                    FileSize = fi.Length;
                    FileDate = fi.CreationTime.ToString();
                }
            }
        }
        catch (Exception ex){
            Console.WriteLine($"FAIL! : {ex.GetType().ToString()}:{ex.Message}");
            throw ex;
        }
    }
}