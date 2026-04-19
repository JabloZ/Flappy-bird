using Godot;
using System;

public partial class PipeManager : Node2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] public float Speed=200.0f;
	[Export] public ScoreCollision ScoreCollision;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        Vector2 pos=Position;
		pos.X-=Speed*(float)delta;
		Position=pos;
		if (GlobalPosition.X < -200.0f)
        {
            QueueFree();
        }
    }
}
