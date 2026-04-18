using Godot;
using System;

public partial class PipeSpawner : Node2D
{
	[Export] public PackedScene Pipe;
	[Export] public float SpawnRate=2.0f;
	[Export] public Node2D PipeContainer;
	[Export] public Timer SpawnTimer;
	
	public override void _Ready()
    {
        SpawnTimer.WaitTime=SpawnRate;
		SpawnTimer.Timeout+=OnSpawnerTimeout;
		SpawnTimer.Start();
    }
	private void OnSpawnerTimeout()
    {
		GD.Print("New pipe");
        Node2D NewPipe=(Node2D)Pipe.Instantiate();
		float RandomY=(float)GD.RandRange(200,500);
		NewPipe.Position=new Vector2(1100,RandomY);

		Node2D NewPipe2=(Node2D)Pipe.Instantiate();
		NewPipe2.RotationDegrees=180f;
		NewPipe2.Position=new Vector2(1100,RandomY-150);
		NewPipe2.Scale = new Vector2(-1, 1);
		PipeContainer.AddChild(NewPipe);
		PipeContainer.AddChild(NewPipe2);
    }
	
}
