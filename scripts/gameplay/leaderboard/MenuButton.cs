using Godot;
using System;

public partial class MenuButton : Button
{
	public override void _Ready()
    {
       
		this.Pressed += MenuOnClick;
    }

	public void MenuOnClick()
    {
		GetTree().Paused = false;
        GetTree().ChangeSceneToFile("res://scenes/main_menu.tscn");
		this.Visible=false;
    }
}
