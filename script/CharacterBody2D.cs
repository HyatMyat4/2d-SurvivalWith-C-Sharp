using Godot;
using System;

public partial class CharacterBody2D : Godot.CharacterBody2D
{
	public const float Speed = 100;
	public const float JumpVelocity = -400.0f;

	public string player_state = "";

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	//public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		Vector2 direction = Input.GetVector("left", "right", "up", "down");

		if (direction.X == 0 && direction.Y == 0)
		{
			player_state = "idle";
		}
		else if (direction.X != 0 && direction.Y != 0)
		{
			player_state = "walk";
		}

		velocity = direction * Speed;

		// if (direction != Vector2.Zero)
		// {
		// 	velocity = direction * Speed;
		// }
		// else
		// {
		// 	velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		// }

		Velocity = velocity;
		play_animations(direction);
		MoveAndSlide();
	}

	public void play_animations(Vector2 direction)
	{
		Console.WriteLine(direction);
		if (player_state == "idle")
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("idle");
		}
		if (direction.Y == -1)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("n-walk");
		}
		else if (direction.X == 1)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("e-walk");
		}
		else if (direction.Y == 1)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("s-walk");
		}
		else if (direction.X == -1)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("w-walk");
		}
		else if (direction.X > 0.5 && direction.Y < -0.5)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("ne-walk");
		}
		else if (direction.X > 0.5 && direction.Y > 0.5)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("sw-walk");
		}
		else if (direction.X < -0.5 && direction.Y < -0.5)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("nw-walk");
		}
	}
}
