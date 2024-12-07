namespace NewLibre;

using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

public class SnapshotRepository{

    public string GetMatchingSnapshotsByName(string name){
        SnapshotContext sc = new SnapshotContext();
        var allItems = sc.Snapshot.Where<Snapshot>(s => s.Name == name).OrderBy<Snapshot, string>(a => a.Created ).ToList<Snapshot>();
        
        Console.WriteLine($"{allItems}");
        Console.WriteLine($"{allItems.Count()}");
        
        foreach (Snapshot i in allItems){
            Console.WriteLine($"{i.Created}, {i.FileHash}");
        }
        //Snapshot ss = sc.Set<Snapshot>().Where<Snapshot>();
        string targetFileName = string.Empty;
        if (File.Exists("/usr/bin/bash")){
           targetFileName = "/usr/bin/bash";
        }
        else{
            targetFileName = "/bin/zsh";
        }
        Snapshot ss = new Snapshot("test",targetFileName);
        var jsonObject = JsonSerializer.Serialize(allItems);
        Console.WriteLine(jsonObject);
        return jsonObject;
    }
}