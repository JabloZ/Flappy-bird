using Godot;
using System;

public partial class LabelScore : Label
{

	// Called when the node enters the scene tree for the first time.
	private int score;
	public override void _Ready()
    {
        score=0;
    }
	public void AddPoints()
    {
        score+=1;
		Text=$"{score}";
    }
}
