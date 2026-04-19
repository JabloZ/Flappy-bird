using Godot;
using System;

public partial class Character : CharacterBody2D
{
	[Export] public float Gravity = 900.0f;
	[Export] public float JumpVelocity = -300.0f;
	[Export] public AudioStreamPlayer2D JumpSound;
	[Export] public float RotationSpeed = 0.60f;
	
	public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
		velocity.Y += Gravity*(float)delta;
		if (Input.IsActionJustPressed("jump"))
		{
			JumpSound.Play();
			velocity.Y = JumpVelocity;
			
		}
		if (velocity.Y < -50)
        {
            RotateTo(-30);
        }
		if (velocity.Y > 200)
        {
            RotateTo(30);
        }
		
		else
        {
            RotateTo(0);
        }
		Velocity=velocity;
		MoveAndSlide();
    }
	private void RotateTo(float targetDegrees)
    {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "rotation_degrees", targetDegrees, RotationSpeed)
		.SetTrans(Tween.TransitionType.Sine)
        .SetEase(Tween.EaseType.Out);
    }
}
