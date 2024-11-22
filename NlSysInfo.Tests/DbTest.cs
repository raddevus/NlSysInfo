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

    [Fact]
    public void AddWithHash(){
        ProcInfo pi = new ("test-proc", "/usr/bin/bash", 1);
        ProcInfoContext pic = new();
        pi.GenSha256Hash();
        pic.Add(pi);
        pic.SaveChanges();
    }


    [Fact]
    public void FileDoesntExistEx(){
        
        Action act = () => new ProcInfo("test-proc", "/usr/bin/fakefile", 1);
        FileNotFoundException exception = Assert.Throws<FileNotFoundException>(act);
        
    }
}
