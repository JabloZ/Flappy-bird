using Godot;
using System;

public partial class FloorCollision : Area2D
{
    [Signal] public delegate void ShowRestartEventHandler();
	public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }
	private void OnBodyEntered(Node2D body)
    {
        EmitSignal(SignalName.ShowRestart);
		GetTree().Paused = true;
    }
}
