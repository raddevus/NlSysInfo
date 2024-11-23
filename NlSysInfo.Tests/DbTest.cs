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
        ProcInfo pi;
        if (File.Exists("/usr/bin/bash")){
           pi = new ("linux-1", "/usr/bin/bash", 1);
        }
        else{
            pi = new ("macOS-1","/bin/zsh",2);
        }
        ProcInfoContext pic = new();
        pic.Add(pi);
        pic.SaveChanges();
    }

    [Fact]
    public void AddWithHash(){
        ProcInfo pi;
        if (File.Exists("/usr/bin/bash")){
           pi = new ("linux-1", "/usr/bin/bash", 1);
        }
        else{
            pi = new ("macOS-1","/bin/zsh",2);
        }
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

    [Fact]
    public void BadPids(){
        ProcInfoService pis = new();
        pis.SaveAllProcs(new int[]{1,2,3,11660});
    }
}
