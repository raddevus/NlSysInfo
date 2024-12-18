namespace NewLibre;

using System.Collections;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    public String GetAllEnvVars(){
        List<object> allEnvVars = new();
        foreach (DictionaryEntry de in Environment.GetEnvironmentVariables()){
            allEnvVars.Add(new {name=de.Key, value=de.Value});
        }
        return JsonSerializer.Serialize(allEnvVars);
    }
}