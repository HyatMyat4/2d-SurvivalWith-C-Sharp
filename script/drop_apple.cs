using Godot;
using System;

public partial class drop_apple : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		falll_from_tree();
	}

	private async void falll_from_tree()
	{
		GetNode<AnimationPlayer>("AnimationPlayer").Play("falling_from_tree");

		await ToSignal(GetTree().CreateTimer(1.5f), "timeout");

		GetNode<AnimationPlayer>("AnimationPlayer").Play("fade");

		await ToSignal(GetTree().CreateTimer(0.3f), "timeout");

		QueueFree();
	}


}
