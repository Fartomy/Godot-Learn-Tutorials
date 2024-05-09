using Godot;

public partial class coin : Area2D
{

	private Node _gameManager;
	private AnimationPlayer _animPlayer;

	public override void _Ready()
	{
		_gameManager = GetNode<Node>("../../GameManager");
		_animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}
	public void OnBodyEntered(Node2D body)
	{
		_gameManager.Call("AddPoint");
		_animPlayer.Play("pickup");
	}
}
