using Godot;
using System;

public partial class apple_tree : Node2D
{
	public string tree_state = "no_apple";

	public Boolean player_in_area = false;

	private PackedScene dropAppleScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dropAppleScene = (PackedScene)ResourceLoader.Load("res://scenes/drop_apple.tscn");
		if (tree_state == "no_apple")
		{
			GetNode<Timer>("Timer").Start();
		}
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (tree_state == "no_apple")
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("no_apples");
		}
		else if (tree_state == "apple")
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("apples");
			if (player_in_area)
			{
				if (Input.IsActionJustPressed("e"))
				{
					GD.Print("IsActionJustPressed");
					tree_state = "no_apple";
					_drop_apple();
				}
			}
		}

	}

	private void _on_pickable_area_body_entered(Node2D body)
	{
		if (body is CharacterBody2D)
		{
			GD.Print("HasMethod");
			player_in_area = true;
		}
	}


	private void _on_pickable_area_body_exited(Node2D body)
	{
		if (body.HasMethod("CharacterBody2D"))
		{
			player_in_area = false;
		}
	}

	private void _on_timer_timeout()
	{
		if (tree_state == "no_apple")
		{
			tree_state = "apple";
		}
	}

	private async void _drop_apple()
	{
		var apple_instance = dropAppleScene.Instantiate();

		if (apple_instance is Node2D)
		{
			Node2D appleNode = (Node2D)apple_instance;

			// Adjust the position based on your needs
			appleNode.GlobalPosition = GetNode<Marker2D>("Marker2D").GlobalPosition;

			// Add the apple instance to the scene or do whatever is necessary
			AddChild(appleNode);
		}
		GetNode<Timer>("Timer").Start();
	}
}













