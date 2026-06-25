using Godot;
using System;

public partial class GameManager : Node2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] public FloorCollision FloorCollision;
	[Export] public FloorCollision RoofCollision;
	[Export] public RestartContainer RestartContainer;
	[Export] public Score Score;
	public override void _Ready()
    {
        FloorCollision.ShowRestart += RestartContainer.ShowRestart;
		RoofCollision.ShowRestart += RestartContainer.ShowRestart;
		FloorCollision.SaveScore += Score.SaveScore;
		RoofCollision.SaveScore += Score.SaveScore;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
