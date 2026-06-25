using Godot;
using System;

public partial class RestartContainer : VBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	[Export] public Godot.Button RestartButton;
	[Export] public Godot.Button MenuButton;
	[Export] public Godot.Button LeaderboardButton;

	public override void _Ready()
    {
		Hide();	
        RestartButton.Pressed += RestartOnClick;
		MenuButton.Pressed += MenuOnClick;
    }
	public void MenuOnClick()
    {
		GetTree().Paused = false;
        GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
		this.Visible=false;
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
