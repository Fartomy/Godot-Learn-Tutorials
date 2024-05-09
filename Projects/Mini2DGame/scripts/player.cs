using Godot;

public partial class player : CharacterBody2D
{
	[Export] public const float Speed = 100.0f;
	[Export] public const float JumpVelocity = -280.0f;

	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	private AnimatedSprite2D _animSprite;

	public override void _Ready()
	{
		_animSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");

		if (direction.X > 0)
			_animSprite.FlipH = false;
		else if (direction.X < 0)
			_animSprite.FlipH = true;

		if (IsOnFloor())
			if (direction.X == 0)
				_animSprite.Play("idle");
			else
				_animSprite.Play("run");
		else
			_animSprite.Play("jump");

		if (direction != Vector2.Zero)
			velocity.X = direction.X * Speed;
		else
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);

		Velocity = velocity;
		MoveAndSlide();
	}
}
