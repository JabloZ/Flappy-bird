using Godot;
using System;
using System.Collections.Generic;

public partial class Score : Node
{
     public override void _Ready()
    {
        using var db = new GameDb();
        db.Database.EnsureCreated();
        GD.Print("[Score] Baza danych gotowa.");
    }
    public void SaveScore(int score)
    {
        GD.Print($"[Score] Sygnał SaveScore odebrany, wynik = {score}");
        try
        {
             using var db = new GameDb();
            db.Scores.Add(new ScoreEntry { Value = score });
            db.SaveChanges();
            GD.Print("Zapisano do bazy danych.");
        }
        catch(Exception e)
        {
            GD.PrintErr($"Nie zapisano do db {e.Message}");
        }
    }
    
}