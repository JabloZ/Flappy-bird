using Godot;
using System;

public partial class Button : Godot.Button
{
	
	public override void _Ready()
    {
        this.Pressed+=ButtonOnClick;
    }

	public void ButtonOnClick()
    {
		GetTree().ChangeSceneToFile("res://scenes/game.tscn");
    }
}
