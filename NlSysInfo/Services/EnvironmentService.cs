namespace NewLibre;
using System.Text.Json;

public class EnvironmentService{

    public String GetSpecialFolders(){
        Environment.SpecialFolder[] allSpecialFolders = (Environment.SpecialFolder[])Enum.GetValues(typeof(Environment.SpecialFolder));
        Dictionary<string,string> specialFoldersOut = new();
        foreach (var folder in allSpecialFolders){
            var folderPath = Environment.GetFolderPath(folder);
            if (!String.IsNullOrEmpty(folderPath)){
                specialFoldersOut.Add(Enum.GetName(typeof(Environment.SpecialFolder), folder)!, folderPath);
                //Console.WriteLine($"{Enum.GetName(typeof(Environment.SpecialFolder), folder)} path: {folderPath} ");
            }
        }
        return JsonSerializer.Serialize(specialFoldersOut);
    }
}