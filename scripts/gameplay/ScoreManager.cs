using Godot;
using System;

public partial class ScoreManager: Node2D
{

	// Called when the node enters the scene tree for the first time.
	[Export] public AudioStreamPlayer2D AdvanceSound;
	[Export] public AudioStreamPlayer2D Advance10Sound;
	[Export] public Label Label;
	public int score;
	public override void _Ready()
    {
        score=0;
    }
	public void AddPoints()
    {
        score+=1;
		Label.Text=$"{score}";
		if (score % 10 == 0)
        {
            Advance10Sound.Play();
        }
        else
        {
            AdvanceSound.Play();
        }
    }
}
