using Godot;
using System;

public partial class FloorCollision : Area2D
{
	public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }
	private void OnBodyEntered(Node2D body)
    {
        GD.Print("KLiknieto");
		GetTree().Paused = true;
    }
}
