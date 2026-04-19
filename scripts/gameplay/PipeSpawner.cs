using Godot;
using System;

public partial class PipeSpawner : Node2D
{
	[Export] public PackedScene Character;
	[Export] public PackedScene Pipe;
	[Export] public float SpawnRate=1.5f;
	[Export] public Node2D PipeContainer;
	[Export] public Timer SpawnTimer;
	[Export] public LabelScore Label;
	[Export] public RestartContainer RestartContainer;
	
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
		NewPipe.Position=new Vector2(1300,RandomY);

		Node2D NewPipe2=(Node2D)Pipe.Instantiate();
		//ScoreArea.PipeCrossed += Label.AddPoints;
		NewPipe2.RotationDegrees=180f;
		NewPipe2.Position=new Vector2(1300,RandomY-120);
		NewPipe2.Scale = new Vector2(-1, 1);
		PipeContainer.AddChild(NewPipe);
		PipeContainer.AddChild(NewPipe2);
		var script=NewPipe2.GetNodeOrNull<ScoreCollision>("ScoreArea");
		var pipeCollision=NewPipe2.GetNodeOrNull<PipeCollision>("PipeArea");
		var pipeCollision2=NewPipe.GetNodeOrNull<PipeCollision>("PipeArea");

		if (script != null)
        {
			script.PipeCrossed += Label.AddPoints;
			
        }
		if (pipeCollision!=null){
			pipeCollision.ShowRestart += RestartContainer.ShowRestart;
			pipeCollision2.ShowRestart += RestartContainer.ShowRestart;
		}
    }
	
}
