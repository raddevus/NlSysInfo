
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace NewLibre;
public class SnapshotContext : DbContext
{
    // The variable name must match the name of the table.
    public DbSet<Snapshot> Snapshot { get; set; }
    
    public string DbPath { get; }

    public SnapshotContext()
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
            foreach (String tableCreate in Utils.allTableCreation){
                command.CommandText = tableCreate;
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine($"{DbPath}");
    }

    // configures the database for use by EF
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}