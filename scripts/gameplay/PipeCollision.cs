using Godot;
using System;

public partial class PipeCollision : Area2D
{
	[Export] public float Speed=200.0f;
	public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }
	
	private void OnBodyEntered(Node2D body)
    {
        GD.Print("KLiknieto");
		GetTree().Paused = true;
    }
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
