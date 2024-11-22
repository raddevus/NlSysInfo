
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace NewLibre;
public class ProcInfoContext : DbContext
{
    // The variable name must match the name of the table.
    public DbSet<ProcInfo> ProcInfo { get; set; }
    
    public string DbPath { get; }

    public ProcInfoContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "nlsysinfo.db");
        Console.WriteLine(DbPath);

        SqliteConnection connection = new SqliteConnection($"Data Source={DbPath}");
        // ########### FYI THE DB is created when it is OPENED ########
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        FileInfo fi = new FileInfo(DbPath);
        // check to see if db file is 0 length, if so, it needs to have table added
        if (fi.Length == 0){
            foreach (String tableCreate in allTableCreation){
                command.CommandText = tableCreate;
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine($"{DbPath}");
    }

    // configures the database for use by EF
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    protected String [] allTableCreation = {
        @"CREATE TABLE ProcInfo
            (
            [ID] INTEGER NOT NULL PRIMARY KEY,
            [Name] NVARCHAR(250) NOT NULL check(length(Name) <= 250),
            [FileName] NVARCHAR(1024) NOT NULL check(length(FileName) <= 1024),
            [FileSize] BIGINT, 
            [FileHash] NVARCHAR(64) NOT NULL check(length(FileHash) <= 64),
            [Created] NVARCHAR(30) default (datetime('now','localtime')) 
                      check(length(Created) <= 30)
            )"
    };

}