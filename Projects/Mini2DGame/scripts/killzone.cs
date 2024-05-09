using Godot;

public partial class killzone : Area2D
{
    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
    }
    private void OnBodyEntered(Node2D body)
    {
        GD.Print("You Died!");
        Engine.TimeScale = 0.2f;
        body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
        timer.Start();
    }

    private void OnTimerTimeout()
    {
        Engine.TimeScale = 1f;
        GetTree().ReloadCurrentScene();
    }
}
