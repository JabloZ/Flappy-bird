using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Score : Node
{
    public static Score Instance { get; private set; }
    public override void _Ready()
    {
        Instance=this;
        using var db = new GameDb();
        db.Database.EnsureCreated();
        GD.Print("DB setup");
    }
    public void SaveScore(int score)
    {
        GD.Print("sygnal savescore");
        try
        {
            GD.Print($"sc:{score}");
            using var db = new GameDb();
            db.Scores.Add(new ScoreEntry { Value = score, ScoreDate=DateTime.Now });
            db.SaveChanges();
            GD.Print("zapisano do db");
        }
        catch(Exception e)
        {
            GD.PrintErr($"Nie zapisano do db {e.Message}");
        }
    }
    public List<ScoreEntry> GetScores(int scores)
    {
        GD.Print("sygnal printscores");
        try
        {
            using var db = new GameDb();
            return db.Scores
                .OrderByDescending(s=>s.Value)
                .Take(scores)
                .ToList();
        }
        catch(Exception ex)
        {
            GD.Print($"blad zwracania scores {ex.Message}");
            return null;
        }
    }
    public void PrintScores()
    {
        var TopScores=GetScores(5);
        foreach(var entry in TopScores)
        {
            GD.Print($"Wynik: {entry.Value} Kiedy: {entry.ScoreDate}");
        }
    }
    
}