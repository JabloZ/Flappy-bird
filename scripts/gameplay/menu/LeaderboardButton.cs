using Godot;
using System;

public partial class LeaderboardButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        Pressed += OnLeaderboardButtonPressed;
    }

	private void OnLeaderboardButtonPressed()
    {
		GetTree().ChangeSceneToFile("res://scenes/leaderboard.tscn");
        
    }
}
