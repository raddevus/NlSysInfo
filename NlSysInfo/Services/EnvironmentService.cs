namespace NewLibre;
using System.Text.Json;

public class EnvironmentService{

    public String GetSpecialFolders(){
        Environment.SpecialFolder[] allSpecialFolders = (Environment.SpecialFolder[])Enum.GetValues(typeof(Environment.SpecialFolder));
        List<object> specialFoldersOut = new();

        foreach (var folder in allSpecialFolders){
            var folderPath = Environment.GetFolderPath(folder);
            if (!String.IsNullOrEmpty(folderPath)){
                var key = Enum.GetName(typeof(Environment.SpecialFolder), folder);
                Console.WriteLine($"key: {key}, folderPath: {folderPath}");
                specialFoldersOut.Add(new {folderName=key, folderPath=folderPath});
            }
        }
        return JsonSerializer.Serialize(specialFoldersOut);
    }
}