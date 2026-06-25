using Godot;
using System;
using System.Collections.Generic;

public partial class LeaderboardManager : Node2D
{
	[Export] public VBoxContainer ScoreList;
	public override void _Ready()
    {
		ScoresView();
        Score.Instance.PrintScores();
    }
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void ScoresView()
    {
		int scores=15;
        var Scores=Score.Instance.GetScores(scores);
		int rank=1;
		foreach(var Score in Scores)
        {
            
            var row=CreateScoreRow(rank, Score);
			ScoreList.AddChild(row);
            rank++;
        }
    }
	private Control CreateScoreRow(int rank, ScoreEntry score)
    {
		var panel = new PanelContainer();
		var styleBox = new StyleBoxFlat();
		styleBox.BgColor = new Color(0, 0, 0);
		styleBox.ContentMarginLeft = 12;
		styleBox.ContentMarginRight = 12;
		styleBox.ContentMarginTop = 6;
		styleBox.ContentMarginBottom = 6;
		panel.AddThemeStyleboxOverride("panel", styleBox);

		var row = new HBoxContainer();
		row.Alignment = BoxContainer.AlignmentMode.Center;
		row.SizeFlagsHorizontal = Control.SizeFlags.ShrinkCenter; 

		var rankLabel = new Label { Text = $"{rank}.", CustomMinimumSize = new Vector2(40, 0) };
		var scoreLabel = new Label { Text = score.Value.ToString(), CustomMinimumSize = new Vector2(100, 0) };
		var dateLabel = new Label { Text = score.ScoreDate.ToString("dd.MM.yyyy") };


		foreach (var label in new[] { rankLabel, scoreLabel, dateLabel })
		{
			label.AddThemeFontSizeOverride("font_size", 28);
			label.AddThemeColorOverride("font_color", Colors.White);
		}

		row.AddChild(rankLabel);
		row.AddChild(scoreLabel);
		row.AddChild(dateLabel);

		panel.AddChild(row);
		return panel; // zwracasz panel, nie row!
    }
    
	public override void _Process(double delta)
    {
        
    }
	
}
