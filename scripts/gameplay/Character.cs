using Godot;
using System;

public partial class Character : CharacterBody2D
{
	[Export] public float Gravity = 900.0f;
	[Export] public float JumpVelocity = -300.0f;
	public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
		velocity.Y += Gravity*(float)delta;
		if (Input.IsActionJustPressed("jump"))
		{
			velocity.Y = JumpVelocity;
		}
		Velocity=velocity;
		MoveAndSlide();
    }
}
