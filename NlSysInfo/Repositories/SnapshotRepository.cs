namespace NewLibre;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

public class SnapshotRepository{

    public string GetMatchingSnapshots(){
        SnapshotContext sc = new SnapshotContext();
        // Snapshot ss = sc.Find<Snapshot>();
        Snapshot ss = new Snapshot("test","/usr/bin/bash");
        var jsonObject = JsonSerializer.Serialize(ss);
        Console.WriteLine(jsonObject);
        return jsonObject;
    }
}