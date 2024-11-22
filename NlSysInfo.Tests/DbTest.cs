using NewLibre;
namespace NlSysInfo.Tests;

public class DbTest
{
    [Fact]
    public void CreateDb(){
        ProcInfoContext pic = new();
        
    }

    [Fact]
    public void AddOneRecord(){
        ProcInfo pi = new ("test-proc", "/usr/bin/bash", 1);
        ProcInfoContext pic = new();
        pic.Add(pi);
        pic.SaveChanges();
    }
}
