
using System.Security.Cryptography;
using System.Text;

namespace NewLibre;

public class Utils{
    public static string GenSha256(string targetFile) 
    { 
        var sha = SHA256.Create();
            using (FileStream fs = new FileStream(targetFile, 
                                        FileMode.Open, 
                                        FileAccess.Read,    
                                        FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                        byte[] hash = sha.ComputeHash(fs);
                        return String.Concat(Array.ConvertAll(hash, x => x.ToString("x2")));
                }
            }
    }

    public static String [] allTableCreation = {
        @"CREATE TABLE ProcInfo
            (
            [ID] INTEGER NOT NULL PRIMARY KEY,
            [Name] NVARCHAR(250) NOT NULL check(length(Name) <= 250),
            [ProcId] INTEGER,
            [FileName] NVARCHAR(1024) NOT NULL check(length(FileName) <= 1024),
            [FileSize] BIGINT, 
            [FileHash] NVARCHAR(64) NULL check(length(FileHash) <= 64),
            [Created] NVARCHAR(30) default (datetime('now','localtime')) 
                      check(length(Created) <= 30)
            )",
            @"CREATE TABLE Snapshot
            (
            [ID] INTEGER NOT NULL PRIMARY KEY,
            [Name] NVARCHAR(250) NOT NULL check(length(Name) <= 250),
            [ProcId] INTEGER,
            [FileName] NVARCHAR(1024) NOT NULL check(length(FileName) <= 1024),
            [FileSize] BIGINT, 
            [FileHash] NVARCHAR(64) NULL check(length(FileHash) <= 64),
            [Created] NVARCHAR(30) default (datetime('now','localtime')) 
                      check(length(Created) <= 30)
            )"
    };
}