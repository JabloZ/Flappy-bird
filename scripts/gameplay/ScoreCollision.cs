using Godot;
using System;

public partial class ScoreCollision : Area2D
{
	// Called when the node enters the scene tree for the first time.
	[Signal] public delegate void PipeCrossedEventHandler();
	
	
	public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	private void OnBodyEntered(Node2D body)
    {
		
        EmitSignal(SignalName.PipeCrossed);
    }
}
