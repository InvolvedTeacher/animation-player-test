using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float speed = 300.0f;
	public const float jump_velocity = -800.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}
		else
		{
			velocity = new Vector2(velocity.X, jump_velocity);
		}

		float direction = Input.GetAxis("left", "right");
		if (direction != 0)
		{
			velocity.X = direction * speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
