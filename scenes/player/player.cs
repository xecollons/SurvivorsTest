using Godot;
using System;

public partial class player : CharacterBody2D
{
	const int MAX_SPEED = 200;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var movementVector = getMovementVector();
		var direction = movementVector.Normalized();
		Velocity = direction * MAX_SPEED;
		MoveAndSlide();
	}

	Vector2 getMovementVector()
	{
		var xMovement = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        var yMovement = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");
        return new Vector2(xMovement, yMovement);
	}
}
