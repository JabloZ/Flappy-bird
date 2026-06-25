using Microsoft.EntityFrameworkCore;
using Godot;

public class GameDb : DbContext
{
    private readonly string _dbPath;
    public GameDb()
    {
        _dbPath = System.IO.Path.Combine(OS.GetUserDataDir(), "game.db");
    }
    public GameDb(string dbPath) // do testow
    {
        _dbPath = dbPath;
    }

    public DbSet<ScoreEntry> Scores { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_dbPath}");
    }
}