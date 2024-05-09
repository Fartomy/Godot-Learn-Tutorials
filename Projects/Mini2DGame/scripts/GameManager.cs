using Godot;

public partial class GameManager : Node
{
    private int _score = 0;

    private Label _scoreLabel;

    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>("ScoreLabel");
    }

    public void AddPoint()
    {
        _score += 1;
        _scoreLabel.Text = "Collected " + _score.ToString() + " coins.";
    }
}
