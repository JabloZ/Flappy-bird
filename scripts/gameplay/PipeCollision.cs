using Godot;
using System;

public partial class PipeCollision : Area2D
{
    [Signal] public delegate void ShowRestartEventHandler();
	[Export] public float Speed=200.0f;
    [Export] public RestartContainer RestartContainer;
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
