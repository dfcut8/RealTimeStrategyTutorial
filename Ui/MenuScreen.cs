using Godot;

public partial class MenuScreen : Control
{
    [Export]
    public required PackedScene FirstLevel { get; set; }

    private Button? playAgainBtn;
    private Button? quitBtn;

    public override void _Ready()
    {
        quitBtn = GetNode<Button>("%QuitBtn");
        quitBtn.Pressed += OnQuitBtnPressed;
        playAgainBtn = GetNode<Button>("%PlayAgainBtn");
        playAgainBtn.Pressed += OnPlayAgainBtnPressed;
    }

    private void OnPlayAgainBtnPressed()
    {
        //GetTree().ChangeSceneToPacked(FirstLevel);
    }

    private void OnQuitBtnPressed()
    {
        GetTree().Quit();
    }

    public override void _Process(double delta) { }
}
