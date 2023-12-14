using Godot;
using System;

public partial class apple_tree : Node2D
{
	public string tree_state = "no_apple";

	public Boolean player_in_area = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		if (tree_state == "no_apple")
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("apples");
			GetNode<Timer>("Timer").Start();
		}
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (tree_state == "no_apple")
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("no_apples");
			Console.WriteLine(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
		}
		else if (tree_state == "apple")
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("apples");
			if (player_in_area)
			{
				if (Input.IsActionJustPressed("e"))
				{
					tree_state = "no_apple";
					GetNode<Timer>("Timer").Start();
				}
			}
		}

	}

	private void _on_pickable_area_body_entered(Node2D body)
	{
		if (body.HasMethod("CharacterBody2D"))
		{
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

	private void _on_growth_time_timeout()
	{
		if (tree_state == "no_apple")
		{
			tree_state = "apple";
		}
	}


}






