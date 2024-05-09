using Godot;

public partial class slime : Node2D
{
	[Export] private float Speed = 60;
	private int direction = 1;
	private Vector2 pos;

	private AnimatedSprite2D _animSprite;
	private RayCast2D _raycastLeft;
	private RayCast2D _raycastRight;

	public override void _Ready()
	{
		_animSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_raycastLeft = GetNode<RayCast2D>("RaycastLeft");
		_raycastRight = GetNode<RayCast2D>("RaycastRight");
		pos = Position;
	}
	public override void _Process(double delta)
	{
		if(_raycastLeft.IsColliding())
		{
			direction = 1;
			_animSprite.FlipH = false;
		}
		if(_raycastRight.IsColliding())
		{
			direction = -1;
			_animSprite.FlipH = true;
		}
		pos.X += direction * Speed * (float)delta;
		Position = pos;
	}
}
