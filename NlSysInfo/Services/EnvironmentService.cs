namespace NewLibre;
using System.Text.Json;

public class EnvironmentService{

    public String GetSpecialFolders(){
        Environment.SpecialFolder[] allSpecialFolders = (Environment.SpecialFolder[])Enum.GetValues(typeof(Environment.SpecialFolder));
        List<(string Key, string Value)> specialFoldersOut = new();

        foreach (var folder in allSpecialFolders){
            var folderPath = Environment.GetFolderPath(folder);
            if (!String.IsNullOrEmpty(folderPath)){
                var key = Enum.GetName(typeof(Environment.SpecialFolder), folder);
                specialFoldersOut.Add((key, folderPath));
                //Console.WriteLine($"{Enum.GetName(typeof(Environment.SpecialFolder), folder)} path: {folderPath} ");
            }
        }
        return JsonSerializer.Serialize(specialFoldersOut);
    }
}