using Godot;
using System;

public partial class RestartContainer : VBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	[Export] public Godot.Button RestartButton;
	
	public override void _Ready()
    {
		Hide();	
        RestartButton.Pressed += RestartOnClick;
		
    }
	public void RestartOnClick(){
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
		this.Visible=false;
	}
	public void ShowRestart()
    {
        Show();
    }
	
}
