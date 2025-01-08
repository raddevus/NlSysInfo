namespace NewLibre;

using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

public class SnapshotRepository{

    public string GetMatchingSnapshotsByName(string name){
        SnapshotContext sc = new SnapshotContext();
        var allItems = sc.Snapshot.Where<Snapshot>(s => s.Name.ToLower() == name.ToLower()).OrderBy<Snapshot, string>(a => a.Created ).ToList<Snapshot>();
        
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

    public string GetNewProcesses(){
        // ### Returns json list of ProcInfo that have never
        // ### been seen before.   Allows user to say,
        // ### What is running right now that has never ran in past?
        // ### (ie - never been captured in snapshot in the past)
        SnapshotContext sc = new SnapshotContext();
        var allDistinctSnap = sc.Snapshot.Select(s => s.Name).Distinct();
        //Console.WriteLine($"{allDistinctSnap.Count()}");
        var retVal = JsonSerializer.Serialize(allDistinctSnap);
        Console.WriteLine($"{retVal}");
        return retVal;
    }
    public void ConvertDatesToIso8601(){
        SnapshotContext sc = new();
        var allRows = sc.Snapshot.Where<Snapshot>(s => s.Id > 0);

        foreach (Snapshot s in allRows){
            s.Created = DateTime.Parse(s.Created).ToString("yyyy-MM-dd HH:mm:ss");
            if ( !String.IsNullOrEmpty(s.FileDate)){
                s.FileDate = DateTime.Parse(s.FileDate).ToString("yyyy-MM-dd HH:mm:ss");
            }
            sc.Update(s);
            sc.SaveChanges();
            Console.WriteLine($"created: {s.Created} : SAVED!! ");
        }
    }
}