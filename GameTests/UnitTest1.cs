using System;
using System.IO;
using System.Linq;
using Xunit;

public class ScoreDbTests
{
    private string NewTestDbPath() => Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.db");

    [Fact]
    public void SavingScore_AddsOneRecord()
    {
        var db = new GameDb(NewTestDbPath());
        db.Database.EnsureCreated();

        db.Scores.Add(new ScoreEntry { Value = 42, ScoreDate = DateTime.Now });
        db.SaveChanges();

        Assert.Equal(1, db.Scores.Count());
    }

    [Fact]
    public void GetTopScores_ReturnsHighestFirst()
    {
        var db = new GameDb(NewTestDbPath());
        db.Database.EnsureCreated();

        db.Scores.Add(new ScoreEntry { Value = 10, ScoreDate = DateTime.Now });
        db.Scores.Add(new ScoreEntry { Value = 99, ScoreDate = DateTime.Now });
        db.SaveChanges();

        var top = db.Scores.OrderByDescending(s => s.Value).First();

        Assert.Equal(99, top.Value);
    }

    [Fact]
    public void EmptyDatabase_HasNoScores()
    {
        var db = new GameDb(NewTestDbPath());
        db.Database.EnsureCreated();

        Assert.Empty(db.Scores);
    }
}