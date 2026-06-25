using Godot;
using System;

public partial class FloorCollision : Area2D
{
    [Signal] public delegate void ShowRestartEventHandler();
    [Signal] public delegate void SaveScoreEventHandler(int score);
    [Export] public AudioStreamPlayer2D HitSound;
    [Export] public ScoreManager ScoreManager{get;set;}
	public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }
	private void OnBodyEntered(Node2D body)
    {
        HitSound.Play();
        EmitSignal(SignalName.ShowRestart);

        EmitSignal(SignalName.SaveScore,ScoreManager.score);
		GetTree().Paused = true;
        
    }
}
