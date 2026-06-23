using Microsoft.EntityFrameworkCore;
using Godot;

public class GameDb: DbContext
{
    public DbSet<ScoreEntry> Scores{get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //zapisujemy do user:// bo res:// moze nie dzialac
        string dbPath=System.IO.Path.Combine(OS.GetUserDataDir(),"game.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}